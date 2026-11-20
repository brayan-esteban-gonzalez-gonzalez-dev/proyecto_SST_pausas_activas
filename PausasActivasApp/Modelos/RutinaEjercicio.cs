namespace PausasActivasApp.Modelos
{
    /// <summary>
    /// Representa un ejercicio dentro de la rutina de una configuración.
    /// Corresponde a una fila de [dbo].[rutina_ejercicios] con join a [ejercicios].
    /// </summary>
    public class RutinaEjercicio
    {
        public int    IdRutina         { get; set; }
        public int    IdConfig         { get; set; }
        public int    IdEjercicio      { get; set; }
        public int    Orden            { get; set; }

        // Datos del ejercicio (desde JOIN con dbo.ejercicios)
        public string  Titulo           { get; set; } = string.Empty;
        public string  Descripcion      { get; set; } = string.Empty;
        public int     DuracionSegundos { get; set; }
        public string? ImagenRuta       { get; set; }

        /// <summary>Texto para mostrar en el ListBox de la rutina.</summary>
        public string TextoEnRutina => $"{Orden}. {Titulo}  ({DuracionSegundos} seg)";

        /// <summary>Texto para mostrar en el ListBox de disponibles.</summary>
        public string TextoDisponible => $"{Titulo}  ({DuracionSegundos} seg)";

        public override string ToString() => TextoEnRutina;
    }
}
