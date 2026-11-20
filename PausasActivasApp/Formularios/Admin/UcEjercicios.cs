using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// UserControl: Gestión de Ejercicios (CRUD completo).
    /// Se carga en el panel de contenido del FrmAdminPrincipal.
    /// </summary>
    public partial class UcEjercicios : UserControl
    {
        public UcEjercicios()
        {
            InitializeComponent();
        }

        // ════════════════════════════════════════════════════════════════════
        // CARGA Y REFRESCO
        // ════════════════════════════════════════════════════════════════════

        private void UcEjercicios_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            CargarEjercicios();
        }

        private void ConfigurarColumnas()
        {
            dgvEjercicios.Columns.Clear();
            dgvEjercicios.AutoGenerateColumns = false;

            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name            = "colId",
                HeaderText      = "ID",
                DataPropertyName = "IdEjercicio",
                Width           = 45,
                ReadOnly        = true
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colTitulo",
                HeaderText       = "Título",
                DataPropertyName = "Titulo",
                Width            = 200,
                ReadOnly         = true
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colDuracion",
                HeaderText       = "Duración",
                DataPropertyName = "DuracionTexto",
                Width            = 90,
                ReadOnly         = true
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colImagen",
                HeaderText       = "Imagen",
                DataPropertyName = "ImagenRuta",
                Width            = 220,
                ReadOnly         = true
            });
            dgvEjercicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colEstado",
                HeaderText       = "Estado",
                DataPropertyName = "EstadoTexto",
                Width            = 90,
                ReadOnly         = true
            });
        }

        private void CargarEjercicios()
        {
            try
            {
                var lista = EjercicioDAL.ObtenerTodos();
                dgvEjercicios.DataSource = lista;
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // EVENTOS DE LA GRILLA
        // ════════════════════════════════════════════════════════════════════

        private void dgvEjercicios_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void dgvEjercicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AbrirEdicion();
        }

        // ════════════════════════════════════════════════════════════════════
        // BOTONES DE ACCIÓN
        // ════════════════════════════════════════════════════════════════════

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using var dlg = new FrmEjercicioDetalle(null);
            if (dlg.ShowDialog() == DialogResult.OK)
                CargarEjercicios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirEdicion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var ej = EjercicioSeleccionado();
            if (ej == null) return;

            var resp = MessageBox.Show(
                $"¿Eliminar el ejercicio \"{ej.Titulo}\"?\n\n" +
                "⚠ Si está asignado a una rutina, no podrá eliminarse.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resp != DialogResult.Yes) return;

            try
            {
                EjercicioDAL.Eliminar(ej.IdEjercicio);
                CargarEjercicios();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Violación de FK: el ejercicio está en una rutina
                MessageBox.Show(
                    "No se puede eliminar: el ejercicio está asignado a una rutina activa.\n" +
                    "Desactívalo en su lugar.",
                    "Error de integridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            var ej = EjercicioSeleccionado();
            if (ej == null) return;

            string accion = ej.Activo ? "desactivar" : "activar";
            var resp = MessageBox.Show(
                $"¿Deseas {accion} el ejercicio \"{ej.Titulo}\"?",
                "Cambiar estado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                EjercicioDAL.CambiarEstado(ej.IdEjercicio, !ej.Activo);
                CargarEjercicios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarEjercicios();
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════

        private Ejercicio? EjercicioSeleccionado()
        {
            if (dgvEjercicios.CurrentRow?.DataBoundItem is Ejercicio ej)
                return ej;
            return null;
        }

        private void AbrirEdicion()
        {
            var ej = EjercicioSeleccionado();
            if (ej == null) return;

            using var dlg = new FrmEjercicioDetalle(ej);
            if (dlg.ShowDialog() == DialogResult.OK)
                CargarEjercicios();
        }

        private void ActualizarBotones()
        {
            bool haySeleccion = EjercicioSeleccionado() != null;
            btnEditar.Enabled        = haySeleccion;
            btnEliminar.Enabled      = haySeleccion;
            btnCambiarEstado.Enabled = haySeleccion;

            if (EjercicioSeleccionado() is Ejercicio ej)
                btnCambiarEstado.Text = ej.Activo ? "⏸ Desactivar" : "▶ Activar";
            else
                btnCambiarEstado.Text = "⏸ Activar/Desactivar";
        }
    }
}
