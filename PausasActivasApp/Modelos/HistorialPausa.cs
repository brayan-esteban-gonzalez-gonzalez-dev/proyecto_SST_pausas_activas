using System;

namespace PausasActivasApp.Modelos
{
    /// <summary>
    /// Representa un registro de la tabla [dbo].[historial_pausas].
    /// </summary>
    public class HistorialPausa
    {
        public int      IdHistorial            { get; set; }
        public int      IdUsuario              { get; set; }
        public DateTime FechaHora              { get; set; }
        public string   Estado                 { get; set; } = string.Empty; // "COMPLETADA" | "POSPUESTA" | "OMITIDA"
        public int      DuracionTotalSegundos  { get; set; }

        // ── Datos calculados o provenientes de JOIN ─────────────────────────
        public string NombreUsuario  { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;

        public string FechaHoraTexto => FechaHora.ToString("dd/MM/yyyy HH:mm:ss");
        public string DuracionTexto  => $"{DuracionTotalSegundos / 60}m {DuracionTotalSegundos % 60}s";

        public string EstadoFormateado => Estado switch
        {
            "COMPLETADA" => "✔ Completada",
            "POSPUESTA"  => "⏸ Pospuesta",
            "OMITIDA"    => "✖ Omitida",
            _            => Estado
        };
    }
}
