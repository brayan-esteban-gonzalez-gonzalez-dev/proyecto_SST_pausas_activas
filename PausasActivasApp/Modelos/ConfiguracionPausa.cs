using System;

namespace PausasActivasApp.Modelos
{
    /// <summary>
    /// Representa una fila de [dbo].[configuracion_pausas].
    /// Solo una instancia puede tener Activo = true al mismo tiempo.
    /// </summary>
    public class ConfiguracionPausa
    {
        public int      IdConfig           { get; set; }
        public int      IntervaloMinutos   { get; set; }
        public TimeSpan HoraInicio         { get; set; }
        public TimeSpan HoraFin            { get; set; }
        public bool     PermitirPosponer   { get; set; }
        public int      MinutosPosponer    { get; set; }
        public bool     Activo             { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        // ── Propiedades calculadas para mostrar en DataGridView ─────────────
        public string HoraInicioTexto => HoraInicio.ToString(@"hh\:mm");
        public string HoraFinTexto    => HoraFin.ToString(@"hh\:mm");
        public string EstadoTexto     => Activo ? "✔ Activa" : "— Inactiva";
        public string PosponerTexto   => PermitirPosponer ? $"Sí ({MinutosPosponer} min)" : "No";
    }
}
