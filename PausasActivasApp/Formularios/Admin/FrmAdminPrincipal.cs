using System;
using System.Drawing;
using System.Windows.Forms;
using PausasActivasApp.Utilidades;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// Panel principal del Administrador.
    /// Contiene un sidebar izquierdo y un área de contenido derecha
    /// donde se cargan los UserControls de cada módulo.
    /// </summary>
    public partial class FrmAdminPrincipal : Form
    {
        // Control activo cargado en el panel de contenido
        private UserControl? _controlActual = null;
        private bool _cerrando = false;

        public FrmAdminPrincipal()
        {
            InitializeComponent();
        }

        // ════════════════════════════════════════════════════════════════════
        // EVENTOS DE FORMULARIO
        // ════════════════════════════════════════════════════════════════════

        private void FrmAdminPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioSesion.Text = $"👤 {SesionActual.Nombre}";
            // Cargar módulo de ejercicios por defecto al abrir
            CargarModulo(new UcEjercicios());
            MarcarBotonActivo(btnEjercicios);
        }

        private void FrmAdminPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si el usuario cierra con la X o se cierra la ventana, volvemos al Login limpiamente
            if (!_cerrando)
            {
                _cerrando = true;
                SesionActual.CerrarSesion();
                var login = Application.OpenForms["FrmLogin"];
                if (login != null)
                {
                    login.Show();
                    (login as PausasActivasApp.Formularios.FrmLogin)?.ReiniciarLogin();
                }
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // BOTONES DEL SIDEBAR
        // ════════════════════════════════════════════════════════════════════

        private void btnEjercicios_Click(object sender, EventArgs e)
        {
            CargarModulo(new UcEjercicios());
            MarcarBotonActivo(btnEjercicios);
        }

        private void btnConfigPausas_Click(object sender, EventArgs e)
        {
            CargarModulo(new UcConfigPausas());
            MarcarBotonActivo(btnConfigPausas);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            CargarModulo(new UcUsuarios());
            MarcarBotonActivo(btnEmpleados);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            CargarModulo(new UcReportes());
            MarcarBotonActivo(btnReportes);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.Yes)
                CerrarSesionYVolver();
        }

        // ════════════════════════════════════════════════════════════════════
        // LÓGICA PRIVADA
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Carga un UserControl en el panel de contenido.</summary>
        private void CargarModulo(UserControl uc)
        {
            _controlActual?.Dispose();
            panelContenido.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(uc);
            _controlActual = uc;
        }

        /// <summary>Resalta el botón activo del sidebar y quita el resalte de los demás.</summary>
        private void MarcarBotonActivo(Button activo)
        {
            Button[] todos = { btnEjercicios, btnConfigPausas, btnEmpleados, btnReportes };
            foreach (var b in todos)
            {
                b.BackColor = b == activo
                    ? Color.FromArgb(0, 86, 130)   // azul oscuro = activo
                    : Color.FromArgb(45, 45, 68);  // gris azulado = inactivo
            }
        }

        private void MostrarProximamente(string modulo)
        {
            panelContenido.Controls.Clear();
            var lbl = new Label
            {
                Text      = $"⏳ Módulo \"{modulo}\" disponible en una fase próxima.",
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Segoe UI", 12F),
                ForeColor = Color.Gray
            };
            panelContenido.Controls.Add(lbl);
        }

        private void CerrarSesionYVolver()
        {
            if (_cerrando) return;
            _cerrando = true;

            SesionActual.CerrarSesion();
            var login = Application.OpenForms["FrmLogin"];
            if (login != null)
            {
                login.Show();
                // Limpiar campos del login
                (login as PausasActivasApp.Formularios.FrmLogin)?.ReiniciarLogin();
            }
            this.Close();
        }
    }
}
