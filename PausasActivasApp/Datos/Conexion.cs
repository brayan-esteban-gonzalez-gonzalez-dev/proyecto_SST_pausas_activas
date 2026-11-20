using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace PausasActivasApp.Datos
{
    /// <summary>
    /// Centraliza la creación de conexiones a SQL Server.
    /// Obtiene la cadena de conexión desde App.config (clave "PausasActivasDB").
    /// </summary>
    public static class Conexion
    {
        // Lee la cadena UNA sola vez al cargar la clase.
        private static readonly string _cadena =
            ConfigurationManager.ConnectionStrings["PausasActivasDB"].ConnectionString;

        /// <summary>
        /// Devuelve una nueva SqlConnection ya abierta.
        /// El llamador es responsable de cerrarla (usar siempre en bloque using).
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            var conn = new SqlConnection(_cadena);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Verifica que la conexión a la BD sea posible.
        /// Útil para mostrar un diagnóstico claro al arrancar la app.
        /// </summary>
        public static bool VerificarConexion(out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                using (var conn = ObtenerConexion())
                {
                    // Si llega aquí, la conexión fue exitosa.
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }
    }
}
