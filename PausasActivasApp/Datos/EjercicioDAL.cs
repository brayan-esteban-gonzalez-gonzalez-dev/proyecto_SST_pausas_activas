using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Datos
{
    /// <summary>
    /// Capa de Acceso a Datos para la tabla [dbo].[ejercicios].
    /// Todas las consultas son parametrizadas.
    /// </summary>
    public static class EjercicioDAL
    {
        // ── SELECT base reutilizado en todos los métodos ────────────────────
        private const string SQL_SELECT = @"
            SELECT id_ejercicio, titulo, descripcion,
                   duracion_segundos, imagen_ruta, activo
            FROM   dbo.ejercicios";

        // ── Mapeo de fila → objeto ──────────────────────────────────────────
        private static Ejercicio MapearFila(SqlDataReader r) => new Ejercicio
        {
            IdEjercicio      = r.GetInt32(0),
            Titulo           = r.GetString(1),
            Descripcion      = r.GetString(2),
            DuracionSegundos = r.GetInt32(3),
            ImagenRuta       = r.IsDBNull(4) ? null : r.GetString(4),
            Activo           = r.GetBoolean(5)
        };

        // ════════════════════════════════════════════════════════════════════
        // CRUD
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Devuelve todos los ejercicios ordenados por id.</summary>
        public static List<Ejercicio> ObtenerTodos()
        {
            var lista = new List<Ejercicio>();
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(SQL_SELECT + " ORDER BY id_ejercicio", conn))
            using (var r    = cmd.ExecuteReader())
                while (r.Read()) lista.Add(MapearFila(r));
            return lista;
        }

        /// <summary>Devuelve solo los ejercicios activos, ordenados por id.</summary>
        public static List<Ejercicio> ObtenerActivos()
        {
            var lista = new List<Ejercicio>();
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(SQL_SELECT + " WHERE activo=1 ORDER BY id_ejercicio", conn))
            using (var r    = cmd.ExecuteReader())
                while (r.Read()) lista.Add(MapearFila(r));
            return lista;
        }

        /// <summary>Inserta un ejercicio nuevo y devuelve el id generado.</summary>
        public static int Insertar(Ejercicio e)
        {
            const string sql = @"
                INSERT INTO dbo.ejercicios (titulo, descripcion, duracion_segundos, imagen_ruta, activo)
                VALUES (@titulo, @descripcion, @duracion, @imagen, @activo);
                SELECT SCOPE_IDENTITY();";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@titulo",      e.Titulo);
                cmd.Parameters.AddWithValue("@descripcion", e.Descripcion);
                cmd.Parameters.AddWithValue("@duracion",    e.DuracionSegundos);
                cmd.Parameters.AddWithValue("@imagen",      (object?)e.ImagenRuta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@activo",      e.Activo);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>Actualiza todos los campos de un ejercicio existente.</summary>
        public static void Actualizar(Ejercicio e)
        {
            const string sql = @"
                UPDATE dbo.ejercicios
                SET    titulo            = @titulo,
                       descripcion       = @descripcion,
                       duracion_segundos = @duracion,
                       imagen_ruta       = @imagen,
                       activo            = @activo
                WHERE  id_ejercicio = @id";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@titulo",      e.Titulo);
                cmd.Parameters.AddWithValue("@descripcion", e.Descripcion);
                cmd.Parameters.AddWithValue("@duracion",    e.DuracionSegundos);
                cmd.Parameters.AddWithValue("@imagen",      (object?)e.ImagenRuta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@activo",      e.Activo);
                cmd.Parameters.AddWithValue("@id",          e.IdEjercicio);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Elimina un ejercicio. Fallará si está en una rutina activa (FK).
        /// El llamador debe capturar SqlException y mostrar mensaje amigable.
        /// </summary>
        public static void Eliminar(int idEjercicio)
        {
            const string sql = "DELETE FROM dbo.ejercicios WHERE id_ejercicio = @id";
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", idEjercicio);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Activa o desactiva un ejercicio sin eliminarlo.</summary>
        public static void CambiarEstado(int idEjercicio, bool nuevoEstado)
        {
            const string sql = "UPDATE dbo.ejercicios SET activo = @activo WHERE id_ejercicio = @id";
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@activo", nuevoEstado);
                cmd.Parameters.AddWithValue("@id",     idEjercicio);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
