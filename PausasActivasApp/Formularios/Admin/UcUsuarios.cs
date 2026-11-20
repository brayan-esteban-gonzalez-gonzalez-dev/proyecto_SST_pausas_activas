using System;
using System.Drawing;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;
using PausasActivasApp.Utilidades;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// UserControl: Gestión de Usuarios / Empleados (CRUD completo).
    /// </summary>
    public partial class UcUsuarios : UserControl
    {
        public UcUsuarios()
        {
            InitializeComponent();
        }

        private void UcUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            CargarUsuarios();
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.AutoGenerateColumns = false;

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colId",
                HeaderText       = "ID",
                DataPropertyName = "IdUsuario",
                Width            = 50,
                ReadOnly         = true
            });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colNombre",
                HeaderText       = "Nombre Completo",
                DataPropertyName = "Nombre",
                Width            = 220,
                ReadOnly         = true
            });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colUsuario",
                HeaderText       = "Nombre de Usuario",
                DataPropertyName = "NombreUsuario",
                Width            = 160,
                ReadOnly         = true
            });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colRol",
                HeaderText       = "Rol",
                DataPropertyName = "Rol",
                Width            = 110,
                ReadOnly         = true
            });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colEstado",
                HeaderText       = "Estado",
                DataPropertyName = "EstadoTexto",
                Width            = 110,
                ReadOnly         = true
            });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colFecha",
                HeaderText       = "Fecha de Registro",
                DataPropertyName = "FechaCreacionTexto",
                Width            = 160,
                ReadOnly         = true
            });
        }

        public void CargarUsuarios()
        {
            try
            {
                var lista = UsuarioDAL.ObtenerTodos();
                dgvUsuarios.DataSource = lista;
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario? UsuarioSeleccionado()
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is Usuario u)
                return u;
            return null;
        }

        private void ActualizarBotones()
        {
            var u = UsuarioSeleccionado();
            bool hay = u != null;

            btnEditar.Enabled = hay;
            btnRestablecerPass.Enabled = hay;

            if (u != null)
            {
                // Seguridad: no permitir que el admin actual desactive su propia cuenta
                bool esPropiaCuenta = (u.IdUsuario == SesionActual.IdUsuario);
                btnCambiarEstado.Enabled = !esPropiaCuenta;
                btnCambiarEstado.Text = u.Activo ? "⏸ Desactivar" : "▶ Activar";
            }
            else
            {
                btnCambiarEstado.Enabled = false;
                btnCambiarEstado.Text = "⏸ Activar/Desactivar";
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                AbrirEdicion();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using var dlg = new FrmUsuarioDetalle(null);
            if (dlg.ShowDialog() == DialogResult.OK)
                CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirEdicion();
        }

        private void AbrirEdicion()
        {
            var u = UsuarioSeleccionado();
            if (u == null) return;

            using var dlg = new FrmUsuarioDetalle(u);
            if (dlg.ShowDialog() == DialogResult.OK)
                CargarUsuarios();
        }

        private void btnRestablecerPass_Click(object sender, EventArgs e)
        {
            var u = UsuarioSeleccionado();
            if (u == null) return;

            using var dlg = new FrmRestablecerPassword(u);
            dlg.ShowDialog();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            var u = UsuarioSeleccionado();
            if (u == null) return;

            if (u.IdUsuario == SesionActual.IdUsuario)
            {
                MessageBox.Show("No puedes desactivar tu propia cuenta en sesión.",
                    "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accion = u.Activo ? "desactivar" : "activar";
            var resp = MessageBox.Show(
                $"¿Deseas {accion} la cuenta de \"{u.Nombre}\" (@{u.NombreUsuario})?",
                "Confirmar cambio de estado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                UsuarioDAL.CambiarEstado(u.IdUsuario, !u.Activo);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}
