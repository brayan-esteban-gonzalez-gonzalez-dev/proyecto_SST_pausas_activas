using System;

namespace PausasActivasApp.Modelos
{
    /// <summary>
    /// Representa un registro de la tabla [dbo].[usuarios].
    /// </summary>
    public class Usuario
    {
        public int      IdUsuario     { get; set; }
        public string   Nombre        { get; set; } = string.Empty;
        public string   NombreUsuario { get; set; } = string.Empty;
        public string   PasswordHash  { get; set; } = string.Empty;
        public string   Rol           { get; set; } = string.Empty;  // "ADMIN" | "EMPLEADO"
        public bool     Activo        { get; set; }
        public DateTime FechaCreacion { get; set; }

        // ── Propiedades calculadas para visualización en DataGridView ───────
        public string EstadoTexto        => Activo ? "✔ Activo" : "✖ Inactivo";
        public string FechaCreacionTexto => FechaCreacion.ToString("dd/MM/yyyy HH:mm");
    }
}
