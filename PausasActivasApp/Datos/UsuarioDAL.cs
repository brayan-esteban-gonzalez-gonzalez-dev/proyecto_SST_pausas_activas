using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PausasActivasApp.Modelos;
using PausasActivasApp.Utilidades;

namespace PausasActivasApp.Datos
{
    /// <summary>
    /// Capa de Acceso a Datos para la tabla [dbo].[usuarios].
    /// Todas las consultas son parametrizadas (prevención de SQL Injection).
    /// </summary>
    public static class UsuarioDAL
    {
        private const string SQL_SELECT = @"
            SELECT id_usuario, nombre, usuario, password_hash, rol, activo, fecha_creacion
            FROM   dbo.usuarios";

        private static Usuario MapearFila(SqlDataReader reader) => new Usuario
        {
            IdUsuario     = reader.GetInt32(0),
            Nombre        = reader.GetString(1),
            NombreUsuario = reader.GetString(2),
            PasswordHash  = reader.GetString(3),
            Rol           = reader.GetString(4),
            Activo        = reader.GetBoolean(5),
            FechaCreacion = reader.GetDateTime(6)
        };

        /// <summary>
        /// Autentica un usuario verificando credenciales y estado de cuenta.
        /// </summary>
        public static Usuario? Autenticar(string nombreUsuario, string passwordCrudo)
        {
            string hashIngresado = Seguridad.HashSHA256(passwordCrudo);

            const string sql = @"
                SELECT id_usuario, nombre, usuario, password_hash, rol, activo, fecha_creacion
                FROM   dbo.usuarios
                WHERE  usuario       = @usuario
                  AND  password_hash = @hash";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario.Trim());
                cmd.Parameters.AddWithValue("@hash",    hashIngresado);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return MapearFila(reader);
                }
            }
        }

        /// <summary>
        /// Devuelve todos los usuarios registrados ordenados por rol y nombre.
        /// </summary>
        public static List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(SQL_SELECT + " ORDER BY rol ASC, nombre ASC", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    lista.Add(MapearFila(reader));
            }
            return lista;
        }

        /// <summary>
        /// Verifica si ya existe un nombre de usuario en la base de datos (evita duplicados).
        /// </summary>
        public static bool ExisteUsuario(string username, int idExcluir = 0)
        {
            const string sql = @"
                SELECT COUNT(1)
                FROM   dbo.usuarios
                WHERE  usuario = @usuario AND id_usuario <> @idExcluir";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@usuario",   username.Trim());
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        /// <summary>
        /// Inserta un nuevo usuario calculando el hash SHA-256 de su contraseña inicial.
        /// </summary>
        public static int Insertar(Usuario u, string passwordPlano)
        {
            string hash = Seguridad.HashSHA256(passwordPlano);

            const string sql = @"
                INSERT INTO dbo.usuarios (nombre, usuario, password_hash, rol, activo, fecha_creacion)
                VALUES (@nombre, @usuario, @hash, @rol, @activo, SYSUTCDATETIME());
                SELECT SCOPE_IDENTITY();";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nombre",  u.Nombre.Trim());
                cmd.Parameters.AddWithValue("@usuario", u.NombreUsuario.Trim());
                cmd.Parameters.AddWithValue("@hash",    hash);
                cmd.Parameters.AddWithValue("@rol",     u.Rol);
                cmd.Parameters.AddWithValue("@activo",  u.Activo);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Actualiza nombre, nombre de usuario, rol y estado activo de un usuario existente.
        /// </summary>
        public static void Actualizar(Usuario u)
        {
            const string sql = @"
                UPDATE dbo.usuarios
                SET    nombre  = @nombre,
                       usuario = @usuario,
                       rol     = @rol,
                       activo  = @activo
                WHERE  id_usuario = @id";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nombre",  u.Nombre.Trim());
                cmd.Parameters.AddWithValue("@usuario", u.NombreUsuario.Trim());
                cmd.Parameters.AddWithValue("@rol",     u.Rol);
                cmd.Parameters.AddWithValue("@activo",  u.Activo);
                cmd.Parameters.AddWithValue("@id",      u.IdUsuario);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Restablece la contraseña de un usuario actualizando su hash SHA-256.
        /// </summary>
        public static void RestablecerPassword(int idUsuario, string nuevaPasswordPlano)
        {
            string nuevoHash = Seguridad.HashSHA256(nuevaPasswordPlano);

            const string sql = @"
                UPDATE dbo.usuarios
                SET    password_hash = @hash
                WHERE  id_usuario = @id";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@hash", nuevoHash);
                cmd.Parameters.AddWithValue("@id",   idUsuario);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Cambia el estado activo/inactivo de una cuenta.
        /// </summary>
        public static void CambiarEstado(int idUsuario, bool nuevoEstado)
        {
            const string sql = @"UPDATE dbo.usuarios SET activo = @activo WHERE id_usuario = @id";

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@activo", nuevoEstado);
                cmd.Parameters.AddWithValue("@id",     idUsuario);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
