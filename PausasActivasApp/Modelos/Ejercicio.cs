namespace PausasActivasApp.Modelos
{
    /// <summary>
    /// Representa un registro de la tabla [dbo].[ejercicios].
    /// </summary>
    public class Ejercicio
    {
        public int    IdEjercicio       { get; set; }
        public string Titulo            { get; set; } = string.Empty;
        public string Descripcion       { get; set; } = string.Empty;
        public int    DuracionSegundos  { get; set; }
        public string? ImagenRuta       { get; set; }   // ruta relativa o null
        public bool   Activo            { get; set; }

        /// <summary>Texto para mostrar en la UI: "X seg"</summary>
        public string DuracionTexto => $"{DuracionSegundos} seg";

        /// <summary>Texto para mostrar estado en DataGridView.</summary>
        public string EstadoTexto => Activo ? "✔ Activo" : "✖ Inactivo";
    }
}
