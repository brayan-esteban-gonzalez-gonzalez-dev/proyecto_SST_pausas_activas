namespace PausasActivasApp.Utilidades
{
    /// <summary>
    /// Almacena los datos del usuario autenticado durante toda la sesión.
    /// Patrón Singleton estático: accesible desde cualquier formulario sin
    /// necesidad de pasar objetos entre ventanas.
    /// Se limpia en Cerrar Sesión para evitar fugas de datos entre sesiones.
    /// </summary>
    public static class SesionActual
    {
        // ── Datos del usuario autenticado ──────────────────────────────────
        public static int    IdUsuario { get; private set; }
        public static string Nombre    { get; private set; } = string.Empty;
        public static string Usuario   { get; private set; } = string.Empty;
        public static string Rol       { get; private set; } = string.Empty;  // "ADMIN" | "EMPLEADO"
        public static bool   EstaActivo { get; private set; }

        // ── Estado de sesión ────────────────────────────────────────────────
        /// <summary>True si hay un usuario autenticado actualmente.</summary>
        public static bool HaySesion => !string.IsNullOrEmpty(Rol);

        /// <summary>True si el usuario actual es Administrador.</summary>
        public static bool EsAdmin => Rol == "ADMIN";

        /// <summary>True si el usuario actual es Empleado.</summary>
        public static bool EsEmpleado => Rol == "EMPLEADO";

        // ── Métodos ─────────────────────────────────────────────────────────

        /// <summary>
        /// Establece los datos de sesión tras un login exitoso.
        /// </summary>
        public static void IniciarSesion(int idUsuario, string nombre, string usuario, string rol, bool activo)
        {
            IdUsuario  = idUsuario;
            Nombre     = nombre;
            Usuario    = usuario;
            Rol        = rol;
            EstaActivo = activo;
        }

        /// <summary>
        /// Limpia todos los datos de sesión. Llamar al hacer logout.
        /// </summary>
        public static void CerrarSesion()
        {
            IdUsuario  = 0;
            Nombre     = string.Empty;
            Usuario    = string.Empty;
            Rol        = string.Empty;
            EstaActivo = false;
        }
    }
}
