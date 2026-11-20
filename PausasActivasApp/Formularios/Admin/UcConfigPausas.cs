using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// UserControl: Configuración de Pausas Activas.
    /// Sección superior: lista de configuraciones + parámetros de la seleccionada.
    /// Sección inferior: editor de rutina de ejercicios (dos listas con orden).
    /// </summary>
    public partial class UcConfigPausas : UserControl
    {
        private ConfiguracionPausa? _configSeleccionada;
        private bool _modoNuevo = false;
        private bool _ignorarCambioSeleccion = false;

        public UcConfigPausas()
        {
            InitializeComponent();
        }

        // ════════════════════════════════════════════════════════════════════
        // CARGA INICIAL
        // ════════════════════════════════════════════════════════════════════

        private void UcConfigPausas_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasDGV();
            CargarConfiguraciones();
            CargarEjerciciosDisponibles();
        }

        private void ConfigurarColumnasDGV()
        {
            dgvConfiguraciones.Columns.Clear();
            dgvConfiguraciones.AutoGenerateColumns = false;

            dgvConfiguraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId",        HeaderText = "ID",        DataPropertyName = "IdConfig",         Width = 40,  ReadOnly = true });
            dgvConfiguraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIntervalo",  HeaderText = "Intervalo", DataPropertyName = "IntervaloMinutos", Width = 75,  ReadOnly = true });
            dgvConfiguraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colInicio",     HeaderText = "Inicio",    DataPropertyName = "HoraInicioTexto",  Width = 65,  ReadOnly = true });
            dgvConfiguraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFin",        HeaderText = "Fin",       DataPropertyName = "HoraFinTexto",     Width = 65,  ReadOnly = true });
            dgvConfiguraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPosponer",   HeaderText = "Posponer",  DataPropertyName = "PosponerTexto",    Width = 90,  ReadOnly = true });
            dgvConfiguraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstado",     HeaderText = "Estado",    DataPropertyName = "EstadoTexto",      Width = 80,  ReadOnly = true });
        }

        // ════════════════════════════════════════════════════════════════════
        // DATOS
        // ════════════════════════════════════════════════════════════════════

        private void CargarConfiguraciones()
        {
            try
            {
                var lista = PausaDAL.ObtenerTodas();
                _ignorarCambioSeleccion = true;
                dgvConfiguraciones.DataSource = null;
                dgvConfiguraciones.DataSource = lista;
                _ignorarCambioSeleccion = false;

                if (lista.Count > 0)
                {
                    dgvConfiguraciones.Rows[0].Selected = true;
                    if (dgvConfiguraciones.Rows[0].DataBoundItem is ConfiguracionPausa cfg)
                    {
                        _configSeleccionada = cfg;
                        _modoNuevo = false;
                        CargarParametros(cfg);
                        CargarRutina(cfg.IdConfig);
                        grpParametros.Text = $"Parámetros — Config #{cfg.IdConfig}";
                    }
                }
                else
                {
                    _configSeleccionada = null;
                    LimpiarFormulario();
                }

                ActualizarBotonesConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar configuraciones:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEjerciciosDisponibles()
        {
            try
            {
                var ejercicios = EjercicioDAL.ObtenerActivos();
                // Los guardamos en Tag del listbox para referencia por ID
                lstDisponibles.Items.Clear();
                foreach (var e in ejercicios)
                {
                    var item = new RutinaEjercicio
                    {
                        IdEjercicio      = e.IdEjercicio,
                        Titulo           = e.Titulo,
                        DuracionSegundos = e.DuracionSegundos,
                        Orden            = 0
                    };
                    lstDisponibles.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejercicios:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRutina(int idConfig)
        {
            try
            {
                lstRutina.Items.Clear();
                var rutina = PausaDAL.ObtenerRutina(idConfig);

                // Reconstruir listas: en la rutina los que están asignados, 
                // en disponibles los que NO están en la rutina
                var idsEnRutina = new HashSet<int>(rutina.Select(r => r.IdEjercicio));

                // Recargar disponibles excluyendo los que ya están en rutina
                lstDisponibles.Items.Clear();
                var todosEjercicios = EjercicioDAL.ObtenerActivos();
                foreach (var e in todosEjercicios)
                {
                    if (!idsEnRutina.Contains(e.IdEjercicio))
                    {
                        lstDisponibles.Items.Add(new RutinaEjercicio
                        {
                            IdEjercicio      = e.IdEjercicio,
                            Titulo           = e.Titulo,
                            DuracionSegundos = e.DuracionSegundos,
                            Orden            = 0
                        });
                    }
                }

                // Cargar los de la rutina en orden
                foreach (var r in rutina)
                    lstRutina.Items.Add(r);

                ActualizarDuracionTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar rutina:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // EVENTOS DEL DataGridView DE CONFIGURACIONES
        // ════════════════════════════════════════════════════════════════════

        private void dgvConfiguraciones_SelectionChanged(object sender, EventArgs e)
        {
            if (_ignorarCambioSeleccion) return;

            if (dgvConfiguraciones.CurrentRow?.DataBoundItem is ConfiguracionPausa cfg)
            {
                _configSeleccionada = cfg;
                _modoNuevo = false;
                CargarParametros(cfg);
                CargarRutina(cfg.IdConfig);
                ActualizarBotonesConfig();
                grpParametros.Text = $"Parámetros — Config #{cfg.IdConfig}";
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // BOTONES DE CONFIGURACIÓN
        // ════════════════════════════════════════════════════════════════════

        private void btnNuevaConfig_Click(object sender, EventArgs e)
        {
            _ignorarCambioSeleccion = true;
            try
            {
                _configSeleccionada = null;
                _modoNuevo = true;

                // Deseleccionar cualquier fila en la grilla
                dgvConfiguraciones.ClearSelection();
                if (dgvConfiguraciones.CurrentCell != null)
                    dgvConfiguraciones.CurrentCell = null;

                // Limpiar campos de texto / parámetros para nueva configuración
                LimpiarFormularioParaNuevo();

                grpParametros.Text = "Parámetros — Nueva Configuración";
                panelParametros.Enabled = true;

                // Limpiar rutina y recargar ejercicios disponibles
                lstDisponibles.Items.Clear();
                lstRutina.Items.Clear();
                CargarEjerciciosDisponibles();
                ActualizarDuracionTotal();

                ActualizarBotonesConfig();
                nudIntervalo.Focus();
            }
            finally
            {
                _ignorarCambioSeleccion = false;
            }
        }

        private void btnActivarConfig_Click(object sender, EventArgs e)
        {
            if (_configSeleccionada == null) return;

            var resp = MessageBox.Show(
                $"¿Activar la Configuración #{_configSeleccionada.IdConfig}?\n\n" +
                "El resto de configuraciones quedarán inactivas.",
                "Activar configuración",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resp != DialogResult.Yes) return;

            try
            {
                PausaDAL.Activar(_configSeleccionada.IdConfig);
                CargarConfiguraciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarConfig_Click(object sender, EventArgs e)
        {
            if (_configSeleccionada == null) return;

            try
            {
                PausaDAL.Eliminar(_configSeleccionada.IdConfig);
                CargarConfiguraciones();
                lstDisponibles.Items.Clear();
                lstRutina.Items.Clear();
                CargarEjerciciosDisponibles();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se puede eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // GUARDAR CONFIGURACIÓN
        // ════════════════════════════════════════════════════════════════════

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            if (!ValidarParametros()) return;

            try
            {
                var config = new ConfiguracionPausa
                {
                    IntervaloMinutos  = (int)nudIntervalo.Value,
                    HoraInicio        = dtpHoraInicio.Value.TimeOfDay,
                    HoraFin           = dtpHoraFin.Value.TimeOfDay,
                    PermitirPosponer  = chkPermitirPosponer.Checked,
                    MinutosPosponer   = chkPermitirPosponer.Checked ? (int)nudMinutosPosponer.Value : 5
                };

                if (_modoNuevo)
                {
                    int nuevoId = PausaDAL.Insertar(config);
                    config.IdConfig = nuevoId;
                    GuardarRutinaActual(nuevoId);
                    MessageBox.Show($"Configuración #{nuevoId} creada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_configSeleccionada != null)
                {
                    config.IdConfig = _configSeleccionada.IdConfig;
                    PausaDAL.Actualizar(config);
                    GuardarRutinaActual(_configSeleccionada.IdConfig);
                    MessageBox.Show("Configuración actualizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarConfiguraciones();
                _modoNuevo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // RUTINA — BOTONES
        // ════════════════════════════════════════════════════════════════════

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstDisponibles.SelectedItem is RutinaEjercicio ej)
            {
                lstDisponibles.Items.Remove(ej);
                ej.Orden = lstRutina.Items.Count + 1;
                ej.IdConfig = _configSeleccionada?.IdConfig ?? 0;
                lstRutina.Items.Add(ej);
                RenumerarRutina();
                ActualizarDuracionTotal();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstRutina.SelectedItem is RutinaEjercicio ej)
            {
                lstRutina.Items.Remove(ej);
                ej.Orden = 0;
                lstDisponibles.Items.Add(ej);
                RenumerarRutina();
                ActualizarDuracionTotal();
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            int idx = lstRutina.SelectedIndex;
            if (idx <= 0) return;

            var item = lstRutina.Items[idx];
            lstRutina.Items.RemoveAt(idx);
            lstRutina.Items.Insert(idx - 1, item);
            lstRutina.SelectedIndex = idx - 1;
            RenumerarRutina();
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            int idx = lstRutina.SelectedIndex;
            if (idx < 0 || idx >= lstRutina.Items.Count - 1) return;

            var item = lstRutina.Items[idx];
            lstRutina.Items.RemoveAt(idx);
            lstRutina.Items.Insert(idx + 1, item);
            lstRutina.SelectedIndex = idx + 1;
            RenumerarRutina();
        }

        private void chkPermitirPosponer_CheckedChanged(object sender, EventArgs e)
        {
            nudMinutosPosponer.Enabled = chkPermitirPosponer.Checked;
            lblMinutosPosponer.Enabled = chkPermitirPosponer.Checked;
            if (chkPermitirPosponer.Checked && string.IsNullOrWhiteSpace(nudMinutosPosponer.Text))
            {
                nudMinutosPosponer.Text = "5";
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════

        private void CargarParametros(ConfiguracionPausa cfg)
        {
            nudIntervalo.Value          = cfg.IntervaloMinutos;
            nudIntervalo.Text           = cfg.IntervaloMinutos.ToString();
            dtpHoraInicio.Value         = DateTime.Today.Add(cfg.HoraInicio);
            dtpHoraFin.Value            = DateTime.Today.Add(cfg.HoraFin);
            chkPermitirPosponer.Checked = cfg.PermitirPosponer;
            nudMinutosPosponer.Value    = cfg.MinutosPosponer > 0 ? cfg.MinutosPosponer : 5;
            nudMinutosPosponer.Text     = cfg.MinutosPosponer > 0 ? cfg.MinutosPosponer.ToString() : (cfg.PermitirPosponer ? "5" : string.Empty);
            nudMinutosPosponer.Enabled  = cfg.PermitirPosponer;
            lblMinutosPosponer.Enabled  = cfg.PermitirPosponer;
            panelParametros.Enabled     = true;
        }

        private void LimpiarFormulario()
        {
            nudIntervalo.Text           = string.Empty;
            dtpHoraInicio.Value         = DateTime.Today.Add(new TimeSpan(8, 0, 0));
            dtpHoraFin.Value            = DateTime.Today.Add(new TimeSpan(17, 0, 0));
            chkPermitirPosponer.Checked = false;
            nudMinutosPosponer.Text     = string.Empty;
            nudMinutosPosponer.Enabled  = false;
            lblMinutosPosponer.Enabled  = false;
            panelParametros.Enabled     = false;
            grpParametros.Text          = "Parámetros (Selecciona una config)";
        }

        private void LimpiarFormularioParaNuevo()
        {
            nudIntervalo.Text           = string.Empty;
            dtpHoraInicio.Value         = DateTime.Today.AddHours(8);
            dtpHoraFin.Value            = DateTime.Today.AddHours(17);
            chkPermitirPosponer.Checked = false;
            nudMinutosPosponer.Text     = string.Empty;
            nudMinutosPosponer.Enabled  = false;
            lblMinutosPosponer.Enabled  = false;
        }

        private bool ValidarParametros()
        {
            if (string.IsNullOrWhiteSpace(nudIntervalo.Text) || !int.TryParse(nudIntervalo.Text.Trim(), out int intervalo) || intervalo < 1 || intervalo > 480)
            {
                MessageBox.Show("Por favor, ingresa un intervalo de pausa válido (entre 1 y 480 minutos).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudIntervalo.Focus();
                return false;
            }
            nudIntervalo.Value = intervalo;

            if (dtpHoraInicio.Value.TimeOfDay >= dtpHoraFin.Value.TimeOfDay)
            {
                MessageBox.Show("La hora de inicio debe ser anterior a la hora de fin.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (chkPermitirPosponer.Checked)
            {
                if (string.IsNullOrWhiteSpace(nudMinutosPosponer.Text) || !int.TryParse(nudMinutosPosponer.Text.Trim(), out int minPosponer) || minPosponer < 1 || minPosponer > 60)
                {
                    MessageBox.Show("Por favor, ingresa los minutos a posponer válidos (entre 1 y 60).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudMinutosPosponer.Focus();
                    return false;
                }
                nudMinutosPosponer.Value = minPosponer;
            }

            return true;
        }

        private void GuardarRutinaActual(int idConfig)
        {
            var ids = new List<int>();
            foreach (RutinaEjercicio item in lstRutina.Items)
                ids.Add(item.IdEjercicio);
            PausaDAL.GuardarRutina(idConfig, ids);
        }

        private void RenumerarRutina()
        {
            for (int i = 0; i < lstRutina.Items.Count; i++)
            {
                if (lstRutina.Items[i] is RutinaEjercicio ej)
                    ej.Orden = i + 1;
            }
            // Forzar repintado del ListBox
            lstRutina.Refresh();
        }

        private void ActualizarDuracionTotal()
        {
            int total = 0;
            foreach (RutinaEjercicio item in lstRutina.Items)
                total += item.DuracionSegundos;
            lblDuracionTotal.Text = $"Duración total de la pausa: {total} seg  ({total / 60} min {total % 60} seg)";
        }

        private void ActualizarBotonesConfig()
        {
            bool hay = _configSeleccionada != null;
            btnActivarConfig.Enabled  = hay && !(_configSeleccionada?.Activo ?? false);
            btnEliminarConfig.Enabled = hay;
        }
    }
}
