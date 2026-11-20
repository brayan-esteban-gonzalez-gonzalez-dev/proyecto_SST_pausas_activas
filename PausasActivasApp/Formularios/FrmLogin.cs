using System;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;
using PausasActivasApp.Utilidades;

namespace PausasActivasApp.Formularios
{
    /// <summary>
    /// Pantalla de inicio de sesión.
    /// Comportamiento al cerrar con la X: la app se oculta (no termina).
    /// El cierre real ocurre desde el menú del NotifyIcon del módulo Empleado.
    /// </summary>
    public partial class FrmLogin : Form
    {
        // ── Control de primer arranque ──────────────────────────────────────
        // Permite que Program.cs sepa si ya se verificó la conexión a BD.
        public static bool ConexionVerificada { get; private set; } = false;

        public FrmLogin()
        {
            InitializeComponent();
        }

        // ════════════════════════════════════════════════════════════════════
        // EVENTOS DE FORMULARIO
        // ════════════════════════════════════════════════════════════════════

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Verificar conexión a BD la primera vez que carga el Login.
            if (!ConexionVerificada)
            {
                if (!Conexion.VerificarConexion(out string error))
                {
                    MessageBox.Show(
                        $"No se pudo conectar a la base de datos.\n\n{error}\n\n" +
                        "Verifique que SQL Server esté activo y la cadena de conexión en App.config sea correcta.",
                        "Error de Conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    // Cierre real de la aplicación si no hay BD.
                    Application.Exit();
                    return;
                }
                ConexionVerificada = true;
            }

            // Limpiar campos y posicionar foco.
            LimpiarCampos();
        }

        // ── Botón Ingresar ──────────────────────────────────────────────────
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        // ── Enter en cualquier campo dispara el login ───────────────────────
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtPassword.Focus(); }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Ingresar(); }
        }

        // ── Cerrar con la X → ocultar, no cerrar ───────────────────────────
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // No terminamos la app; simplemente ocultamos la ventana.
                e.Cancel = true;
                this.Hide();
            }
            // Si CloseReason es ApplicationExitCall, se deja cerrar normalmente.
        }

        // ════════════════════════════════════════════════════════════════════
        // LÓGICA PRIVADA
        // ════════════════════════════════════════════════════════════════════

        private void Ingresar()
        {
            // ── Validación de campos vacíos ─────────────────────────────────
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MostrarError("Ingresa tu nombre de usuario.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MostrarError("Ingresa tu contraseña.");
                txtPassword.Focus();
                return;
            }

            // ── Autenticación ───────────────────────────────────────────────
            try
            {
                btnIngresar.Enabled = false;
                lblMensaje.Text     = "Verificando...";
                lblMensaje.ForeColor = System.Drawing.Color.DarkGray;
                Application.DoEvents(); // refresca la UI antes de la consulta

                Usuario? usuario = UsuarioDAL.Autenticar(txtUsuario.Text.Trim(), txtPassword.Text);

                if (usuario == null)
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // ── Cuenta inactiva ─────────────────────────────────────────
                if (!usuario.Activo)
                {
                    MostrarError("Tu cuenta está desactivada. Contacta al administrador.");
                    LimpiarCampos();
                    return;
                }

                // ── Login exitoso: guardar sesión ───────────────────────────
                SesionActual.IniciarSesion(
                    usuario.IdUsuario,
                    usuario.Nombre,
                    usuario.NombreUsuario,
                    usuario.Rol,
                    usuario.Activo);

                this.Hide();
                AbrirModulo(usuario.Rol);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al conectar con la base de datos:\n{ex.Message}");
            }
            finally
            {
                btnIngresar.Enabled = true;
                if (lblMensaje.Text == "Verificando...")
                    lblMensaje.Text = string.Empty;
            }
        }

        /// <summary>Redirige al módulo correspondiente según el rol.</summary>
        private void AbrirModulo(string rol)
        {
            if (rol == "ADMIN")
            {
                var frmAdmin = new Admin.FrmAdminPrincipal();
                frmAdmin.Show();
                this.Hide();
            }
            else if (rol == "EMPLEADO")
            {
                var frmEmpleado = new Empleado.FrmEmpleadoBandeja();
                frmEmpleado.Show();
                this.Hide();
            }
        }

        private void MostrarError(string mensaje)
        {
            lblMensaje.Text      = mensaje;
            lblMensaje.ForeColor = System.Drawing.Color.Firebrick;
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            lblMensaje.Text = string.Empty;
            txtUsuario.Focus();
        }

        /// <summary>
        /// Llamado por FrmAdminPrincipal al cerrar sesión para limpiar la UI.
        /// </summary>
        public void ReiniciarLogin() => LimpiarCampos();
    }
}
