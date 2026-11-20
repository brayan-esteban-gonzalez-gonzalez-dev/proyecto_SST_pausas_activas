using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Datos
{
    /// <summary>
    /// Capa de acceso a datos para la tabla [dbo].[historial_pausas].
    /// </summary>
    public static class HistorialDAL
    {
        /// <summary>
        /// Inserta un nuevo registro de pausa realizada, pospuesta u omitida.
        /// </summary>
        public static int Registrar(HistorialPausa h)
        {
            const string sql = @"
                INSERT INTO dbo.historial_pausas (id_usuario, fecha_hora, estado, duracion_total_segundos)
                VALUES (@idUsuario, SYSUTCDATETIME(), @estado, @duracion);
                SELECT SCOPE_IDENTITY();";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", h.IdUsuario);
                cmd.Parameters.AddWithValue("@estado",    h.Estado);
                cmd.Parameters.AddWithValue("@duracion",  h.DuracionTotalSegundos);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Obtiene el historial de pausas filtrado por rango de fechas, usuario y/o estado.
        /// </summary>
        public static List<HistorialPausa> ObtenerHistorial(
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null,
            int? idUsuario = null,
            string? estado = null)
        {
            var lista = new List<HistorialPausa>();

            string sql = @"
                SELECT h.id_historial, h.id_usuario, h.fecha_hora, h.estado, h.duracion_total_segundos,
                       u.usuario, u.nombre
                FROM   dbo.historial_pausas h
                JOIN   dbo.usuarios         u ON u.id_usuario = h.id_usuario
                WHERE  1 = 1";

            if (fechaDesde.HasValue)
                sql += " AND h.fecha_hora >= @desde";

            if (fechaHasta.HasValue)
                sql += " AND h.fecha_hora <= @hasta";

            if (idUsuario.HasValue && idUsuario.Value > 0)
                sql += " AND h.id_usuario = @idUsuario";

            if (!string.IsNullOrWhiteSpace(estado) && estado != "TODOS")
                sql += " AND h.estado = @estado";

            sql += " ORDER BY h.fecha_hora DESC";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                if (fechaDesde.HasValue)
                    cmd.Parameters.AddWithValue("@desde", fechaDesde.Value);

                if (fechaHasta.HasValue)
                    cmd.Parameters.AddWithValue("@hasta", fechaHasta.Value);

                if (idUsuario.HasValue && idUsuario.Value > 0)
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario.Value);

                if (!string.IsNullOrWhiteSpace(estado) && estado != "TODOS")
                    cmd.Parameters.AddWithValue("@estado", estado);

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new HistorialPausa
                        {
                            IdHistorial           = r.GetInt32(0),
                            IdUsuario             = r.GetInt32(1),
                            FechaHora             = r.GetDateTime(2),
                            Estado                = r.GetString(3),
                            DuracionTotalSegundos = r.GetInt32(4),
                            NombreUsuario         = r.GetString(5),
                            NombreCompleto        = r.GetString(6)
                        });
                    }
                }
            }

            return lista;
        }
    }
}
