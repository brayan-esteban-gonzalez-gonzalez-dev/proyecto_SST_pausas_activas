using System;
using System.Drawing;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;
using PausasActivasApp.Utilidades;

namespace PausasActivasApp.Formularios.Empleado
{
    /// <summary>
    /// Formulario controlador en segundo plano para el módulo de Empleado.
    /// No se muestra en la barra de tareas; reside en la bandeja del sistema (NotifyIcon).
    /// </summary>
    public partial class FrmEmpleadoBandeja : Form
    {
        private ConfiguracionPausa? _config;
        private int _segundosRestantes = 0;
        private bool _enPausaActiva = false;
        private bool _cerrando = false;

        public FrmEmpleadoBandeja()
        {
            InitializeComponent();
        }

        private void FrmEmpleadoBandeja_Load(object sender, EventArgs e)
        {
            // Ocultar formulario de la vista principal
            this.Opacity           = 0;
            this.ShowInTaskbar     = false;
            this.WindowState       = FormWindowState.Minimized;
            this.Visible           = false;

            // Configurar ícono del sistema
            notifyIconEmpleado.Icon    = SystemIcons.Application;
            notifyIconEmpleado.Text    = "Pausas Activas — Empleado";
            notifyIconEmpleado.Visible = true;

            itemUsuario.Text = $"👤 Sesión: {SesionActual.Nombre}";

            // Cargar configuración inicial desde la BD
            SincronizarConfiguracion();

            timerCuentaRegresiva.Start();
            timerSyncBD.Start();

            // Mensaje de bienvenida en bandeja
            notifyIconEmpleado.ShowBalloonTip(
                3000,
                "Pausas Activas Iniciadas",
                $"Hola {SesionActual.Nombre}, la aplicación cuidará tu salud laboral en segundo plano.",
                ToolTipIcon.Info);
        }

        private void SincronizarConfiguracion()
        {
            try
            {
                var nuevaConfig = PausaDAL.ObtenerActiva();
                if (nuevaConfig != null)
                {
                    bool esPrimeraCarga = (_config == null);
                    _config = nuevaConfig;

                    if (esPrimeraCarga)
                    {
                        _segundosRestantes = Math.Max(1, _config.IntervaloMinutos * 60);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al sincronizar configuración: {ex.Message}");
            }
        }

        private void timerCuentaRegresiva_Tick(object sender, EventArgs e)
        {
            if (_config == null) return;

            TimeSpan ahora = DateTime.Now.TimeOfDay;

            // Verificar si estamos dentro de la jornada laboral
            if (ahora < _config.HoraInicio || ahora > _config.HoraFin)
            {
                itemProximaPausa.Text   = "🌙 Fuera de jornada laboral";
                notifyIconEmpleado.Text = "Pausas Activas: Fuera de horario laboral";
                return;
            }

            _segundosRestantes--;

            int minutos  = Math.Max(0, _segundosRestantes / 60);
            int segundos = Math.Max(0, _segundosRestantes % 60);

            string textoTiempo = $"{minutos:D2}:{segundos:D2}";
            itemProximaPausa.Text   = $"⏱ Próxima pausa en: {textoTiempo}";
            notifyIconEmpleado.Text = $"Pausas Activas: {textoTiempo} restantes";

            if (_segundosRestantes <= 0)
            {
                LanzarPausaActiva();
            }
        }

        private void timerSyncBD_Tick(object sender, EventArgs e)
        {
            SincronizarConfiguracion();
        }

        private void LanzarPausaActiva()
        {
            if (_enPausaActiva) return;
            if (_config == null) return;

            try
            {
                _enPausaActiva = true;
                timerCuentaRegresiva.Stop();

                var rutina = PausaDAL.ObtenerRutina(_config.IdConfig);

                if (rutina.Count == 0)
                {
                    notifyIconEmpleado.ShowBalloonTip(
                        4000,
                        "Sin rutina de pausas",
                        "El administrador no ha asignado ejercicios a la rutina activa.",
                        ToolTipIcon.Warning);

                    _segundosRestantes = 300; // reintentar en 5 minutos
                    timerCuentaRegresiva.Start();
                    return;
                }

                using var frmPausa = new FrmPausaActiva(_config, rutina);
                frmPausa.ShowDialog();

                // Evaluar resultado de la pausa
                if (frmPausa.EstadoResultado == "POSPUESTA")
                {
                    _segundosRestantes = Math.Max(1, _config.MinutosPosponer * 60);
                }
                else
                {
                    // COMPLETADA u OMITIDA: reinicia con el intervalo normal
                    _segundosRestantes = Math.Max(1, _config.IntervaloMinutos * 60);
                }
            }
            finally
            {
                _enPausaActiva = false;
                timerCuentaRegresiva.Start();
            }
        }

        private void notifyIconEmpleado_DoubleClick(object sender, EventArgs e)
        {
            if (_config == null) return;

            int minutos  = _segundosRestantes / 60;
            int segundos = _segundosRestantes % 60;

            notifyIconEmpleado.ShowBalloonTip(
                2500,
                "Tiempo para la próxima pausa",
                $"Faltan {minutos} min y {segundos} seg.\nHorario: {_config.HoraInicioTexto} a {_config.HoraFinTexto}",
                ToolTipIcon.Info);
        }

        private void itemIniciarAhora_Click(object sender, EventArgs e)
        {
            LanzarPausaActiva();
        }

        private void itemCerrarSesion_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            _cerrando = true;
            timerCuentaRegresiva.Stop();
            timerSyncBD.Stop();
            notifyIconEmpleado.Visible = false;

            SesionActual.CerrarSesion();

            var login = Application.OpenForms["FrmLogin"];
            if (login != null)
            {
                login.Show();
                (login as PausasActivasApp.Formularios.FrmLogin)?.ReiniciarLogin();
            }

            this.Close();
        }

        private void itemSalir_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "¿Deseas salir por completo de Pausas Activas?",
                "Salir de la aplicación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            _cerrando = true;
            timerCuentaRegresiva.Stop();
            timerSyncBD.Stop();
            notifyIconEmpleado.Visible = false;

            Application.Exit();
        }

        private void FrmEmpleadoBandeja_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_cerrando && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                notifyIconEmpleado.Visible = false;
            }
        }
    }
}
