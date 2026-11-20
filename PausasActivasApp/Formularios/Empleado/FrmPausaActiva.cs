using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;
using PausasActivasApp.Utilidades;

namespace PausasActivasApp.Formularios.Empleado
{
    /// <summary>
    /// Ventana emergente interactiva de la pausa activa.
    /// Se muestra al frente de cualquier otra ventana (TopMost).
    /// </summary>
    public partial class FrmPausaActiva : Form
    {
        private readonly ConfiguracionPausa _config;
        private readonly List<RutinaEjercicio> _rutina;

        private int _indiceEjercicioActual = 0;
        private int _segundosRestantesEjercicio = 0;
        private int _duracionTotalEjercicioActual = 0;
        private int _segundosEjecutadosTotales = 0;

        private string _estadoFinal = "OMITIDA"; // Por defecto si cierra con la X
        private bool _finalizadoControlado = false;

        public string EstadoResultado => _estadoFinal;

        public FrmPausaActiva(ConfiguracionPausa config, List<RutinaEjercicio> rutina)
        {
            InitializeComponent();
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _rutina = rutina ?? new List<RutinaEjercicio>();
        }

        private void FrmPausaActiva_Load(object sender, EventArgs e)
        {
            if (_rutina.Count == 0)
            {
                MessageBox.Show("No hay ejercicios configurados en la rutina activa.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _finalizadoControlado = true;
                this.Close();
                return;
            }

            // Configurar botón Posponer según parámetros del Administrador
            btnPosponer.Visible = _config.PermitirPosponer;
            btnPosponer.Text    = $"⏸ Posponer ({_config.MinutosPosponer} min)";

            _indiceEjercicioActual = 0;
            _segundosEjecutadosTotales = 0;
            CargarEjercicioActual();

            timerEjercicio.Start();
        }

        private void CargarEjercicioActual()
        {
            if (_indiceEjercicioActual >= _rutina.Count)
            {
                FinalizarRutinaCompleta();
                return;
            }

            var ej = _rutina[_indiceEjercicioActual];
            lblEjercicioNum.Text = $"Ejercicio {_indiceEjercicioActual + 1} de {_rutina.Count}";
            lblTituloEjercicio.Text = ej.Titulo;
            txtDescripcion.Text = ej.Descripcion;

            _duracionTotalEjercicioActual = Math.Max(1, ej.DuracionSegundos);
            _segundosRestantesEjercicio = _duracionTotalEjercicioActual;

            // Actualizar barras de progreso
            pbTotal.Maximum = _rutina.Count;
            pbTotal.Value   = _indiceEjercicioActual + 1;

            pbEjercicio.Maximum = _duracionTotalEjercicioActual;
            pbEjercicio.Value   = _duracionTotalEjercicioActual;

            ActualizarTextoTiempo();
            CargarRecursoVisual(ej.ImagenRuta);
        }

        private void CargarRecursoVisual(string? rutaRelativa)
        {
            picEjercicio.Image?.Dispose();
            picEjercicio.Image = null;

            if (string.IsNullOrWhiteSpace(rutaRelativa))
            {
                picEjercicio.BackColor = Color.FromArgb(240, 240, 240);
                return;
            }

            string rutaCompleta = Path.IsPathRooted(rutaRelativa)
                ? rutaRelativa
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

            if (File.Exists(rutaCompleta))
            {
                try
                {
                    // Image.FromFile mantiene la animación en GIFs nativamente en PictureBox
                    picEjercicio.Image = Image.FromFile(rutaCompleta);
                }
                catch
                {
                    picEjercicio.Image = null;
                }
            }
        }

        private void timerEjercicio_Tick(object sender, EventArgs e)
        {
            _segundosRestantesEjercicio--;
            _segundosEjecutadosTotales++;

            if (_segundosRestantesEjercicio >= 0)
            {
                pbEjercicio.Value = _segundosRestantesEjercicio;
                ActualizarTextoTiempo();
            }

            if (_segundosRestantesEjercicio <= 0)
            {
                // Avanzar al siguiente ejercicio
                AvanzarSiguiente();
            }
        }

        private void ActualizarTextoTiempo()
        {
            int minutos  = _segundosRestantesEjercicio / 60;
            int segundos = _segundosRestantesEjercicio % 60;
            lblTiempo.Text = $"{minutos:D2}:{segundos:D2}";
        }

        private void AvanzarSiguiente()
        {
            _indiceEjercicioActual++;
            if (_indiceEjercicioActual < _rutina.Count)
            {
                CargarEjercicioActual();
            }
            else
            {
                FinalizarRutinaCompleta();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            AvanzarSiguiente();
        }

        private void btnPosponer_Click(object sender, EventArgs e)
        {
            timerEjercicio.Stop();
            _estadoFinal = "POSPUESTA";
            _finalizadoControlado = true;

            RegistrarEnHistorial();

            MessageBox.Show(
                $"Pausa activa pospuesta por {_config.MinutosPosponer} minutos.\n¡Te avisaremos nuevamente cuando sea hora!",
                "Pausa Pospuesta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "¿Seguro que deseas omitir esta pausa activa?",
                "Omitir Pausa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                timerEjercicio.Stop();
                _estadoFinal = "OMITIDA";
                _finalizadoControlado = true;

                RegistrarEnHistorial();
                this.Close();
            }
        }

        private void FinalizarRutinaCompleta()
        {
            timerEjercicio.Stop();
            _estadoFinal = "COMPLETADA";
            _finalizadoControlado = true;

            RegistrarEnHistorial();

            MessageBox.Show(
                "¡Excelente trabajo! Has completado tu rutina de pausas activas. 🎉\nContinúa con tu jornada laboral renovado.",
                "Rutina Completada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void RegistrarEnHistorial()
        {
            try
            {
                var h = new HistorialPausa
                {
                    IdUsuario             = SesionActual.IdUsuario,
                    Estado                = _estadoFinal,
                    DuracionTotalSegundos = _segundosEjecutadosTotales
                };

                HistorialDAL.Registrar(h);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al registrar historial: {ex.Message}");
            }
        }

        private void FrmPausaActiva_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerEjercicio.Stop();
            picEjercicio.Image?.Dispose();

            if (!_finalizadoControlado)
            {
                _estadoFinal = "OMITIDA";
                RegistrarEnHistorial();
            }
        }
    }
}
