using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Datos
{
    /// <summary>
    /// DAL para configuracion_pausas y rutina_ejercicios.
    /// Todas las consultas son parametrizadas.
    /// </summary>
    public static class PausaDAL
    {
        // ════════════════════════════════════════════════════════════════════
        // CONFIGURACIÓN DE PAUSAS
        // ════════════════════════════════════════════════════════════════════

        private static ConfiguracionPausa MapearConfig(SqlDataReader r) => new ConfiguracionPausa
        {
            IdConfig            = r.GetInt32(0),
            IntervaloMinutos    = r.GetInt32(1),
            HoraInicio          = r.GetTimeSpan(2),
            HoraFin             = r.GetTimeSpan(3),
            PermitirPosponer    = r.GetBoolean(4),
            MinutosPosponer     = r.GetInt32(5),
            Activo              = r.GetBoolean(6),
            UltimaActualizacion = r.GetDateTime(7)
        };

        private const string SQL_SELECT_CONFIG = @"
            SELECT id_config, intervalo_minutos, hora_inicio, hora_fin,
                   permitir_posponer, minutos_posponer, activo, ultima_actualizacion
            FROM   dbo.configuracion_pausas";

        /// <summary>Devuelve todas las configuraciones ordenadas: activa primero.</summary>
        public static List<ConfiguracionPausa> ObtenerTodas()
        {
            var lista = new List<ConfiguracionPausa>();
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(SQL_SELECT_CONFIG + " ORDER BY activo DESC, id_config", conn))
            using (var r    = cmd.ExecuteReader())
                while (r.Read()) lista.Add(MapearConfig(r));
            return lista;
        }

        /// <summary>Devuelve la configuración activa actual, o null si no hay ninguna.</summary>
        public static ConfiguracionPausa? ObtenerActiva()
        {
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(SQL_SELECT_CONFIG + " WHERE activo = 1", conn))
            using (var r    = cmd.ExecuteReader())
                return r.Read() ? MapearConfig(r) : null;
        }

        /// <summary>Inserta una nueva configuración (inactiva por defecto) y devuelve su id.</summary>
        public static int Insertar(ConfiguracionPausa c)
        {
            const string sql = @"
                INSERT INTO dbo.configuracion_pausas
                    (intervalo_minutos, hora_inicio, hora_fin,
                     permitir_posponer, minutos_posponer, activo, ultima_actualizacion)
                VALUES
                    (@intervalo, @hinicio, @hfin,
                     @posponer, @minPosponer, 0, SYSUTCDATETIME());
                SELECT SCOPE_IDENTITY();";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                AgregarParametros(cmd, c);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>Actualiza los parámetros de una configuración existente.</summary>
        public static void Actualizar(ConfiguracionPausa c)
        {
            const string sql = @"
                UPDATE dbo.configuracion_pausas
                SET    intervalo_minutos  = @intervalo,
                       hora_inicio        = @hinicio,
                       hora_fin           = @hfin,
                       permitir_posponer  = @posponer,
                       minutos_posponer   = @minPosponer,
                       ultima_actualizacion = SYSUTCDATETIME()
                WHERE  id_config = @id";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                AgregarParametros(cmd, c);
                cmd.Parameters.AddWithValue("@id", c.IdConfig);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Activa la configuración indicada y desactiva todas las demás.
        /// Se ejecuta en transacción para garantizar consistencia.
        /// </summary>
        public static void Activar(int idConfig)
        {
            const string sql = @"
                UPDATE dbo.configuracion_pausas SET activo = 0;
                UPDATE dbo.configuracion_pausas SET activo = 1,
                       ultima_actualizacion = SYSUTCDATETIME()
                WHERE  id_config = @id;";

            using (var conn = Conexion.ObtenerConexion())
            using (var tx   = conn.BeginTransaction())
            using (var cmd  = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@id", idConfig);
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
        }

        /// <summary>
        /// Elimina una configuración y su rutina (CASCADE).
        /// Lanza excepción si la configuración está activa.
        /// </summary>
        public static void Eliminar(int idConfig)
        {
            const string sqlCheck = "SELECT activo FROM dbo.configuracion_pausas WHERE id_config = @id";
            const string sqlDel   = "DELETE FROM dbo.configuracion_pausas WHERE id_config = @id";

            using (var conn = Conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand(sqlCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idConfig);
                    var activo = (bool?)cmd.ExecuteScalar();
                    if (activo == true)
                        throw new InvalidOperationException(
                            "No se puede eliminar la configuración activa.\nActiva otra primero.");
                }
                using (var cmd = new SqlCommand(sqlDel, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idConfig);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // RUTINA DE EJERCICIOS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Devuelve los ejercicios asignados a la rutina de una configuración, en orden.
        /// </summary>
        public static List<RutinaEjercicio> ObtenerRutina(int idConfig)
        {
            const string sql = @"
                SELECT r.id_rutina, r.id_config, r.id_ejercicio, r.orden,
                       e.titulo, e.duracion_segundos, e.descripcion, e.imagen_ruta
                FROM   dbo.rutina_ejercicios r
                JOIN   dbo.ejercicios        e ON e.id_ejercicio = r.id_ejercicio
                WHERE  r.id_config = @id
                ORDER  BY r.orden";

            var lista = new List<RutinaEjercicio>();
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", idConfig);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new RutinaEjercicio
                        {
                            IdRutina         = r.GetInt32(0),
                            IdConfig         = r.GetInt32(1),
                            IdEjercicio      = r.GetInt32(2),
                            Orden            = r.GetInt32(3),
                            Titulo           = r.GetString(4),
                            DuracionSegundos = r.GetInt32(5),
                            Descripcion      = r.GetString(6),
                            ImagenRuta       = r.IsDBNull(7) ? null : r.GetString(7)
                        });
            }
            return lista;
        }

        /// <summary>
        /// Reemplaza toda la rutina de una configuración con la lista de ejercicios
        /// proporcionada (en el orden del índice de la lista).
        /// Opera en transacción para garantizar atomicidad.
        /// </summary>
        public static void GuardarRutina(int idConfig, List<int> idsOrdenados)
        {
            const string sqlDelete = "DELETE FROM dbo.rutina_ejercicios WHERE id_config = @id";
            const string sqlInsert = @"
                INSERT INTO dbo.rutina_ejercicios (id_config, id_ejercicio, orden)
                VALUES (@idConfig, @idEjercicio, @orden)";

            using (var conn = Conexion.ObtenerConexion())
            using (var tx   = conn.BeginTransaction())
            {
                using (var cmd = new SqlCommand(sqlDelete, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", idConfig);
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < idsOrdenados.Count; i++)
                {
                    using (var cmd = new SqlCommand(sqlInsert, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@idConfig",    idConfig);
                        cmd.Parameters.AddWithValue("@idEjercicio", idsOrdenados[i]);
                        cmd.Parameters.AddWithValue("@orden",       i + 1);
                        cmd.ExecuteNonQuery();
                    }
                }

                tx.Commit();
            }
        }

        // ── Helper privado ──────────────────────────────────────────────────
        private static void AgregarParametros(SqlCommand cmd, ConfiguracionPausa c)
        {
            cmd.Parameters.AddWithValue("@intervalo",   c.IntervaloMinutos);
            cmd.Parameters.AddWithValue("@hinicio",     c.HoraInicio);
            cmd.Parameters.AddWithValue("@hfin",        c.HoraFin);
            cmd.Parameters.AddWithValue("@posponer",    c.PermitirPosponer);
            cmd.Parameters.AddWithValue("@minPosponer", c.MinutosPosponer);
        }
    }
}
