using System;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// Diálogo modal para crear o editar un usuario.
    /// </summary>
    public partial class FrmUsuarioDetalle : Form
    {
        private readonly Usuario? _usuarioOriginal;

        public FrmUsuarioDetalle(Usuario? usuarioEditar)
        {
            InitializeComponent();
            _usuarioOriginal = usuarioEditar;
        }

        private void FrmUsuarioDetalle_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("EMPLEADO");
            cmbRol.Items.Add("ADMIN");

            if (_usuarioOriginal == null)
            {
                // Modo Nuevo
                this.Text         = "Nuevo Usuario";
                lblTitulo.Text    = "Nuevo Usuario";
                cmbRol.SelectedItem = "EMPLEADO";
                chkActivo.Checked = true;
                panelPasswords.Visible = true;
                lblAvisoEdicion.Visible = false;
            }
            else
            {
                // Modo Editar
                this.Text           = "Editar Usuario";
                lblTitulo.Text      = "Editar Usuario";
                txtNombre.Text      = _usuarioOriginal.Nombre;
                txtUsuario.Text     = _usuarioOriginal.NombreUsuario;
                cmbRol.SelectedItem = _usuarioOriginal.Rol;
                chkActivo.Checked   = _usuarioOriginal.Activo;
                panelPasswords.Visible = false;
                lblAvisoEdicion.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                string nombre   = txtNombre.Text.Trim();
                string username = txtUsuario.Text.Trim();
                string rol      = cmbRol.SelectedItem?.ToString() ?? "EMPLEADO";
                bool activo     = chkActivo.Checked;

                // Verificar duplicados
                int idExcluir = _usuarioOriginal?.IdUsuario ?? 0;
                if (UsuarioDAL.ExisteUsuario(username, idExcluir))
                {
                    MessageBox.Show($"El nombre de usuario '@{username}' ya está en uso por otra cuenta.",
                        "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (_usuarioOriginal == null)
                {
                    // Alta nuevo usuario
                    var nuevo = new Usuario
                    {
                        Nombre        = nombre,
                        NombreUsuario = username,
                        Rol           = rol,
                        Activo        = activo
                    };

                    UsuarioDAL.Insertar(nuevo, txtPassword.Text);
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Edición de usuario existente
                    _usuarioOriginal.Nombre        = nombre;
                    _usuarioOriginal.NombreUsuario = username;
                    _usuarioOriginal.Rol           = rol;
                    _usuarioOriginal.Activo        = activo;

                    UsuarioDAL.Actualizar(_usuarioOriginal);
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre completo es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (txtUsuario.Text.Contains(" "))
            {
                MessageBox.Show("El nombre de usuario no debe contener espacios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un rol válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            if (_usuarioOriginal == null)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Ingresa una contraseña para el usuario.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text.Length < 4)
                {
                    MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPasswordConfirm.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
