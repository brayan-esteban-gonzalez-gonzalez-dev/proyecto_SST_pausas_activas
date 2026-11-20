using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// UserControl: Reportes e Historial de Pausas Activas.
    /// Incluye filtros por fecha, empleado y estado, tarjetas con métricas y exportación a CSV.
    /// </summary>
    public partial class UcReportes : UserControl
    {
        private List<HistorialPausa> _historialFiltrado = new List<HistorialPausa>();

        public UcReportes()
        {
            InitializeComponent();
        }

        private void UcReportes_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            CargarComboUsuarios();
            CargarComboEstados();
            RestablecerFiltros();
            ConsultarReporte();
        }

        private void ConfigurarColumnas()
        {
            dgvReportes.Columns.Clear();
            dgvReportes.AutoGenerateColumns = false;

            dgvReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colId",
                HeaderText       = "ID",
                DataPropertyName = "IdHistorial",
                Width            = 45,
                ReadOnly         = true
            });
            dgvReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colFecha",
                HeaderText       = "Fecha y Hora",
                DataPropertyName = "FechaHoraTexto",
                Width            = 160,
                ReadOnly         = true
            });
            dgvReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colEmpleado",
                HeaderText       = "Empleado",
                DataPropertyName = "NombreCompleto",
                Width            = 220,
                ReadOnly         = true
            });
            dgvReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colUsuario",
                HeaderText       = "Usuario",
                DataPropertyName = "NombreUsuario",
                Width            = 140,
                ReadOnly         = true
            });
            dgvReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colEstado",
                HeaderText       = "Estado",
                DataPropertyName = "EstadoFormateado",
                Width            = 120,
                ReadOnly         = true
            });
            dgvReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name             = "colDuracion",
                HeaderText       = "Tiempo Invertido",
                DataPropertyName = "DuracionTexto",
                Width            = 140,
                ReadOnly         = true
            });
        }

        private void CargarComboUsuarios()
        {
            try
            {
                cmbUsuario.Items.Clear();

                var todosItem = new Usuario { IdUsuario = 0, Nombre = "Todos los empleados" };
                cmbUsuario.Items.Add(todosItem);

                var usuarios = UsuarioDAL.ObtenerTodos();
                foreach (var u in usuarios)
                    cmbUsuario.Items.Add(u);

                cmbUsuario.DisplayMember = "Nombre";
                cmbUsuario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar combo usuarios: {ex.Message}");
            }
        }

        private void CargarComboEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("TODOS");
            cmbEstado.Items.Add("COMPLETADA");
            cmbEstado.Items.Add("POSPUESTA");
            cmbEstado.Items.Add("OMITIDA");
            cmbEstado.SelectedIndex = 0;
        }

        private void RestablecerFiltros()
        {
            // Mes en curso por defecto
            DateTime hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;

            if (cmbUsuario.Items.Count > 0)
                cmbUsuario.SelectedIndex = 0;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 0;
        }

        private void ConsultarReporte()
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1); // final del día

                int? idUsuario = null;
                if (cmbUsuario.SelectedItem is Usuario u && u.IdUsuario > 0)
                    idUsuario = u.IdUsuario;

                string? estado = cmbEstado.SelectedItem?.ToString();

                _historialFiltrado = HistorialDAL.ObtenerHistorial(desde, hasta, idUsuario, estado);
                dgvReportes.DataSource = _historialFiltrado;

                CalcularMetricas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar historial:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricas()
        {
            int total = _historialFiltrado.Count;
            int completadas = _historialFiltrado.Count(h => h.Estado == "COMPLETADA");
            int pospuestas  = _historialFiltrado.Count(h => h.Estado == "POSPUESTA");
            int omitidas    = _historialFiltrado.Count(h => h.Estado == "OMITIDA");
            int segundosTotales = _historialFiltrado.Sum(h => h.DuracionTotalSegundos);

            double pctComp = total > 0 ? (completadas * 100.0 / total) : 0;
            double pctPosp = total > 0 ? (pospuestas  * 100.0 / total) : 0;
            double pctOmit = total > 0 ? (omitidas    * 100.0 / total) : 0;

            lblMetricaTotal.Text        = total.ToString();
            lblMetricaCompletadas.Text  = $"{completadas} ({pctComp:F1}%)";
            lblMetricaPospuestas.Text   = $"{pospuestas} ({pctPosp:F1}%)";
            lblMetricaOmitidas.Text     = $"{omitidas} ({pctOmit:F1}%)";

            int min = segundosTotales / 60;
            int seg = segundosTotales % 60;
            lblMetricaTiempo.Text       = $"{min}m {seg}s";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.",
                    "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConsultarReporte();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            RestablecerFiltros();
            ConsultarReporte();
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            if (_historialFiltrado.Count == 0)
            {
                MessageBox.Show("No hay registros en el reporte actual para exportar.",
                    "Exportar reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Title      = "Exportar Reporte de Pausas Activas",
                Filter     = "Archivo CSV (delimitado por comas)|*.csv",
                FileName   = $"Reporte_PausasActivas_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                // Encabezados
                sb.AppendLine("ID;Fecha y Hora;Empleado;Usuario;Estado;Duracion_Segundos;Tiempo_Formateado");

                foreach (var h in _historialFiltrado)
                {
                    sb.AppendLine(string.Format("{0};\"{1}\";\"{2}\";\"{3}\";\"{4}\";{5};\"{6}\"",
                        h.IdHistorial,
                        h.FechaHoraTexto,
                        h.NombreCompleto.Replace("\"", "\"\""),
                        h.NombreUsuario.Replace("\"", "\"\""),
                        h.EstadoFormateado,
                        h.DuracionTotalSegundos,
                        h.DuracionTexto));
                }

                // UTF-8 con BOM para que Excel en español reconozca caracteres y tildes correctamente
                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show(
                    $"Reporte exportado exitosamente:\n{sfd.FileName}",
                    "Exportación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar archivo:\n{ex.Message}",
                    "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
