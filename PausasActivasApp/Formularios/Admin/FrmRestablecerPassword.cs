using System;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// Diálogo modal para restablecer la contraseña de un usuario.
    /// </summary>
    public partial class FrmRestablecerPassword : Form
    {
        private readonly Usuario _usuario;

        public FrmRestablecerPassword(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        private void FrmRestablecerPassword_Load(object sender, EventArgs e)
        {
            lblUsuarioInfo.Text = $"Usuario: {_usuario.Nombre} (@{_usuario.NombreUsuario})";
            txtPassword.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingresa la nueva contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordConfirm.Focus();
                return;
            }

            try
            {
                UsuarioDAL.RestablecerPassword(_usuario.IdUsuario, txtPassword.Text);
                MessageBox.Show($"Contraseña actualizada con éxito para '{_usuario.NombreUsuario}'.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restablecer la contraseña:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
