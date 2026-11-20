namespace PausasActivasApp.Formularios.Admin
{
    partial class UcConfigPausas
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            // ── Controles principales ───────────────────────────────────────
            this.lblModuloTitulo     = new System.Windows.Forms.Label();
            this.separadorTop        = new System.Windows.Forms.Label();
            // Sección superior izquierda: lista de configs
            this.grpConfigs          = new System.Windows.Forms.GroupBox();
            this.dgvConfiguraciones  = new System.Windows.Forms.DataGridView();
            this.panelBotonesConfig  = new System.Windows.Forms.Panel();
            this.btnNuevaConfig      = new System.Windows.Forms.Button();
            this.btnActivarConfig    = new System.Windows.Forms.Button();
            this.btnEliminarConfig   = new System.Windows.Forms.Button();
            // Sección superior derecha: parámetros
            this.grpParametros       = new System.Windows.Forms.GroupBox();
            this.panelParametros     = new System.Windows.Forms.Panel();
            this.lblTituloParametros = new System.Windows.Forms.Label();
            this.lblIntervalo        = new System.Windows.Forms.Label();
            this.nudIntervalo        = new System.Windows.Forms.NumericUpDown();
            this.lblMinutos          = new System.Windows.Forms.Label();
            this.lblHoraInicio       = new System.Windows.Forms.Label();
            this.dtpHoraInicio       = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin          = new System.Windows.Forms.Label();
            this.dtpHoraFin          = new System.Windows.Forms.DateTimePicker();
            this.chkPermitirPosponer = new System.Windows.Forms.CheckBox();
            this.lblMinutosPosponer  = new System.Windows.Forms.Label();
            this.nudMinutosPosponer  = new System.Windows.Forms.NumericUpDown();
            this.lblMinPosLabel      = new System.Windows.Forms.Label();
            this.btnGuardarConfig    = new System.Windows.Forms.Button();
            // Sección inferior: Rutina
            this.separadorMid        = new System.Windows.Forms.Label();
            this.lblRutinaTitulo     = new System.Windows.Forms.Label();
            this.lblDuracionTotal    = new System.Windows.Forms.Label();
            this.panelRutina         = new System.Windows.Forms.Panel();
            this.grpDisponibles      = new System.Windows.Forms.GroupBox();
            this.lstDisponibles      = new System.Windows.Forms.ListBox();
            this.panelBotonesRutina  = new System.Windows.Forms.Panel();
            this.btnAgregar          = new System.Windows.Forms.Button();
            this.btnQuitar           = new System.Windows.Forms.Button();
            this.btnSubir            = new System.Windows.Forms.Button();
            this.btnBajar            = new System.Windows.Forms.Button();
            this.grpRutina           = new System.Windows.Forms.GroupBox();
            this.lstRutina           = new System.Windows.Forms.ListBox();

            this.grpConfigs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfiguraciones)).BeginInit();
            this.panelBotonesConfig.SuspendLayout();
            this.grpParametros.SuspendLayout();
            this.panelParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosPosponer)).BeginInit();
            this.panelRutina.SuspendLayout();
            this.grpDisponibles.SuspendLayout();
            this.grpRutina.SuspendLayout();
            this.panelBotonesRutina.SuspendLayout();
            this.SuspendLayout();

            // ── lblModuloTitulo ─────────────────────────────────────────────
            this.lblModuloTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblModuloTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblModuloTitulo.Location  = new System.Drawing.Point(10, 8);
            this.lblModuloTitulo.Name      = "lblModuloTitulo";
            this.lblModuloTitulo.Size      = new System.Drawing.Size(400, 30);
            this.lblModuloTitulo.Text      = "⚙️  Configuración de Pausas Activas";

            // ── separadorTop ────────────────────────────────────────────────
            this.separadorTop.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.separadorTop.Location  = new System.Drawing.Point(10, 44);
            this.separadorTop.Name      = "separadorTop";
            this.separadorTop.Size      = new System.Drawing.Size(960, 1);

            // ════════════════════════════════════════════════════════════════
            // GRP IZQUIERDO: Lista de configuraciones
            // ════════════════════════════════════════════════════════════════
            this.grpConfigs.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpConfigs.Location = new System.Drawing.Point(10, 52);
            this.grpConfigs.Name     = "grpConfigs";
            this.grpConfigs.Size     = new System.Drawing.Size(490, 240);
            this.grpConfigs.Text     = "Configuraciones guardadas";
            this.grpConfigs.Controls.Add(this.dgvConfiguraciones);
            this.grpConfigs.Controls.Add(this.panelBotonesConfig);

            // dgvConfiguraciones
            this.dgvConfiguraciones.AllowUserToAddRows    = false;
            this.dgvConfiguraciones.AllowUserToDeleteRows = false;
            this.dgvConfiguraciones.BackgroundColor       = System.Drawing.SystemColors.Window;
            this.dgvConfiguraciones.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvConfiguraciones.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvConfiguraciones.Font                  = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvConfiguraciones.GridColor             = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvConfiguraciones.Location              = new System.Drawing.Point(10, 22);
            this.dgvConfiguraciones.MultiSelect           = false;
            this.dgvConfiguraciones.Name                  = "dgvConfiguraciones";
            this.dgvConfiguraciones.ReadOnly              = true;
            this.dgvConfiguraciones.RowHeadersVisible     = false;
            this.dgvConfiguraciones.RowTemplate.Height    = 28;
            this.dgvConfiguraciones.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfiguraciones.Size                  = new System.Drawing.Size(468, 165);
            this.dgvConfiguraciones.SelectionChanged     += new System.EventHandler(this.dgvConfiguraciones_SelectionChanged);

            // panelBotonesConfig
            this.panelBotonesConfig.Location = new System.Drawing.Point(10, 193);
            this.panelBotonesConfig.Name     = "panelBotonesConfig";
            this.panelBotonesConfig.Size     = new System.Drawing.Size(468, 38);
            this.panelBotonesConfig.Controls.Add(this.btnNuevaConfig);
            this.panelBotonesConfig.Controls.Add(this.btnActivarConfig);
            this.panelBotonesConfig.Controls.Add(this.btnEliminarConfig);

            System.Action<System.Windows.Forms.Button, string, int, System.Drawing.Color> cfgB =
                (b, t, x, c) => {
                    b.BackColor = c; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    b.ForeColor = System.Drawing.Color.White;
                    b.Location = new System.Drawing.Point(x, 2); b.Size = new System.Drawing.Size(148, 32);
                    b.Text = t; b.Cursor = System.Windows.Forms.Cursors.Hand;
                };

            cfgB(this.btnNuevaConfig,    "➕ Nueva config",   0,   System.Drawing.Color.FromArgb(0, 140, 70));
            cfgB(this.btnActivarConfig,  "✔ Activar",         154, System.Drawing.Color.FromArgb(0, 100, 160));
            cfgB(this.btnEliminarConfig, "🗑 Eliminar",        308, System.Drawing.Color.FromArgb(190, 50, 50));

            this.btnNuevaConfig.Name     = "btnNuevaConfig";
            this.btnActivarConfig.Name   = "btnActivarConfig";
            this.btnEliminarConfig.Name  = "btnEliminarConfig";
            this.btnNuevaConfig.Click   += new System.EventHandler(this.btnNuevaConfig_Click);
            this.btnActivarConfig.Click += new System.EventHandler(this.btnActivarConfig_Click);
            this.btnEliminarConfig.Click += new System.EventHandler(this.btnEliminarConfig_Click);

            // ════════════════════════════════════════════════════════════════
            // GRP DERECHO: Parámetros
            // ════════════════════════════════════════════════════════════════
            this.grpParametros.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpParametros.Location = new System.Drawing.Point(510, 52);
            this.grpParametros.Name     = "grpParametros";
            this.grpParametros.Size     = new System.Drawing.Size(460, 240);
            this.grpParametros.Text     = "Parámetros";
            this.grpParametros.Controls.Add(this.panelParametros);

            this.panelParametros.Location = new System.Drawing.Point(8, 22);
            this.panelParametros.Size     = new System.Drawing.Size(444, 210);
            this.panelParametros.Enabled  = false;
            this.panelParametros.Name     = "panelParametros";
            this.panelParametros.Controls.Add(this.lblTituloParametros);
            this.panelParametros.Controls.Add(this.lblIntervalo);
            this.panelParametros.Controls.Add(this.nudIntervalo);
            this.panelParametros.Controls.Add(this.lblMinutos);
            this.panelParametros.Controls.Add(this.lblHoraInicio);
            this.panelParametros.Controls.Add(this.dtpHoraInicio);
            this.panelParametros.Controls.Add(this.lblHoraFin);
            this.panelParametros.Controls.Add(this.dtpHoraFin);
            this.panelParametros.Controls.Add(this.chkPermitirPosponer);
            this.panelParametros.Controls.Add(this.lblMinutosPosponer);
            this.panelParametros.Controls.Add(this.nudMinutosPosponer);
            this.panelParametros.Controls.Add(this.lblMinPosLabel);
            this.panelParametros.Controls.Add(this.btnGuardarConfig);

            // lblTituloParametros
            this.lblTituloParametros.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloParametros.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTituloParametros.Location  = new System.Drawing.Point(10, 4);
            this.lblTituloParametros.Name      = "lblTituloParametros";
            this.lblTituloParametros.Size      = new System.Drawing.Size(425, 22);
            this.lblTituloParametros.Text      = "Selecciona una configuración";

            // lblIntervalo
            this.lblIntervalo.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIntervalo.Location = new System.Drawing.Point(10, 32);
            this.lblIntervalo.Name     = "lblIntervalo";
            this.lblIntervalo.Size     = new System.Drawing.Size(130, 20);
            this.lblIntervalo.Text     = "Intervalo de pausa:";

            // nudIntervalo
            this.nudIntervalo.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.nudIntervalo.Location = new System.Drawing.Point(145, 29);
            this.nudIntervalo.Maximum  = 480;
            this.nudIntervalo.Minimum  = 1;
            this.nudIntervalo.Name     = "nudIntervalo";
            this.nudIntervalo.Size     = new System.Drawing.Size(75, 25);
            this.nudIntervalo.Value    = 60;

            // lblMinutos
            this.lblMinutos.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMinutos.ForeColor = System.Drawing.Color.Gray;
            this.lblMinutos.Location  = new System.Drawing.Point(225, 32);
            this.lblMinutos.Name      = "lblMinutos";
            this.lblMinutos.Size      = new System.Drawing.Size(60, 20);
            this.lblMinutos.Text      = "minutos";

            // lblHoraInicio
            this.lblHoraInicio.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoraInicio.Location = new System.Drawing.Point(10, 66);
            this.lblHoraInicio.Name     = "lblHoraInicio";
            this.lblHoraInicio.Size     = new System.Drawing.Size(130, 20);
            this.lblHoraInicio.Text     = "Hora de inicio:";

            // dtpHoraInicio
            this.dtpHoraInicio.Font       = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHoraInicio.Format     = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location   = new System.Drawing.Point(145, 63);
            this.dtpHoraInicio.Name       = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size       = new System.Drawing.Size(95, 25);

            // lblHoraFin
            this.lblHoraFin.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoraFin.Location = new System.Drawing.Point(10, 100);
            this.lblHoraFin.Name     = "lblHoraFin";
            this.lblHoraFin.Size     = new System.Drawing.Size(130, 20);
            this.lblHoraFin.Text     = "Hora de fin:";

            // dtpHoraFin
            this.dtpHoraFin.Font       = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHoraFin.Format     = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location   = new System.Drawing.Point(145, 97);
            this.dtpHoraFin.Name       = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size       = new System.Drawing.Size(95, 25);

            // chkPermitirPosponer
            this.chkPermitirPosponer.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkPermitirPosponer.Location  = new System.Drawing.Point(10, 134);
            this.chkPermitirPosponer.Name      = "chkPermitirPosponer";
            this.chkPermitirPosponer.Size      = new System.Drawing.Size(210, 22);
            this.chkPermitirPosponer.Text      = "Permitir posponer pausa";
            this.chkPermitirPosponer.CheckedChanged += new System.EventHandler(this.chkPermitirPosponer_CheckedChanged);

            // lblMinutosPosponer
            this.lblMinutosPosponer.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMinutosPosponer.Location = new System.Drawing.Point(10, 168);
            this.lblMinutosPosponer.Name     = "lblMinutosPosponer";
            this.lblMinutosPosponer.Size     = new System.Drawing.Size(130, 20);
            this.lblMinutosPosponer.Text     = "Minutos a posponer:";

            // nudMinutosPosponer
            this.nudMinutosPosponer.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.nudMinutosPosponer.Location = new System.Drawing.Point(145, 165);
            this.nudMinutosPosponer.Maximum  = 60;
            this.nudMinutosPosponer.Minimum  = 1;
            this.nudMinutosPosponer.Name     = "nudMinutosPosponer";
            this.nudMinutosPosponer.Size     = new System.Drawing.Size(75, 25);
            this.nudMinutosPosponer.Value    = 10;

            // lblMinPosLabel
            this.lblMinPosLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMinPosLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblMinPosLabel.Location  = new System.Drawing.Point(225, 168);
            this.lblMinPosLabel.Name      = "lblMinPosLabel";
            this.lblMinPosLabel.Size      = new System.Drawing.Size(60, 20);
            this.lblMinPosLabel.Text      = "minutos";

            // btnGuardarConfig
            this.btnGuardarConfig.BackColor = System.Drawing.Color.FromArgb(0, 140, 70);
            this.btnGuardarConfig.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarConfig.FlatAppearance.BorderSize = 0;
            this.btnGuardarConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarConfig.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarConfig.ForeColor = System.Drawing.Color.White;
            this.btnGuardarConfig.Location  = new System.Drawing.Point(235, 160);
            this.btnGuardarConfig.Name      = "btnGuardarConfig";
            this.btnGuardarConfig.Size      = new System.Drawing.Size(198, 36);
            this.btnGuardarConfig.Text      = "💾 Guardar cambios";
            this.btnGuardarConfig.Click    += new System.EventHandler(this.btnGuardarConfig_Click);

            // ════════════════════════════════════════════════════════════════
            // SEPARADOR + TÍTULOS RUTINA
            // ════════════════════════════════════════════════════════════════
            this.separadorMid.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.separadorMid.Location  = new System.Drawing.Point(10, 300);
            this.separadorMid.Name      = "separadorMid"; this.separadorMid.Size = new System.Drawing.Size(960, 1);

            this.lblRutinaTitulo.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRutinaTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblRutinaTitulo.Location  = new System.Drawing.Point(10, 308);
            this.lblRutinaTitulo.Name      = "lblRutinaTitulo";
            this.lblRutinaTitulo.Size      = new System.Drawing.Size(500, 25);
            this.lblRutinaTitulo.Text      = "📋  Rutina de ejercicios (para la config seleccionada)";

            this.lblDuracionTotal.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDuracionTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblDuracionTotal.Location  = new System.Drawing.Point(10, 334);
            this.lblDuracionTotal.Name      = "lblDuracionTotal";
            this.lblDuracionTotal.Size      = new System.Drawing.Size(500, 18);
            this.lblDuracionTotal.Text      = "Duración total: 0 seg";

            // ════════════════════════════════════════════════════════════════
            // PANEL RUTINA: 2 listas + botones centrales
            // ════════════════════════════════════════════════════════════════
            this.panelRutina.Location = new System.Drawing.Point(10, 356);
            this.panelRutina.Name     = "panelRutina";
            this.panelRutina.Size     = new System.Drawing.Size(960, 230);
            this.panelRutina.Controls.Add(this.grpDisponibles);
            this.panelRutina.Controls.Add(this.panelBotonesRutina);
            this.panelRutina.Controls.Add(this.grpRutina);

            // grpDisponibles
            this.grpDisponibles.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDisponibles.Location = new System.Drawing.Point(0, 0);
            this.grpDisponibles.Name     = "grpDisponibles";
            this.grpDisponibles.Size     = new System.Drawing.Size(420, 225);
            this.grpDisponibles.Text     = "Ejercicios disponibles";
            this.grpDisponibles.Controls.Add(this.lstDisponibles);

            this.lstDisponibles.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.ItemHeight   = 20;
            this.lstDisponibles.Location     = new System.Drawing.Point(8, 20);
            this.lstDisponibles.Name         = "lstDisponibles";
            this.lstDisponibles.Size         = new System.Drawing.Size(404, 196);
            this.lstDisponibles.DisplayMember = "TextoDisponible";

            // panelBotonesRutina (centro)
            this.panelBotonesRutina.Location = new System.Drawing.Point(425, 50);
            this.panelBotonesRutina.Name     = "panelBotonesRutina";
            this.panelBotonesRutina.Size     = new System.Drawing.Size(110, 150);
            this.panelBotonesRutina.Controls.Add(this.btnAgregar);
            this.panelBotonesRutina.Controls.Add(this.btnQuitar);
            this.panelBotonesRutina.Controls.Add(this.btnSubir);
            this.panelBotonesRutina.Controls.Add(this.btnBajar);

            System.Action<System.Windows.Forms.Button, string, int, System.Drawing.Color> cfgBR =
                (b, t, y, c) => {
                    b.BackColor = c; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                    b.ForeColor = System.Drawing.Color.White;
                    b.Location = new System.Drawing.Point(5, y); b.Size = new System.Drawing.Size(100, 32);
                    b.Text = t; b.Cursor = System.Windows.Forms.Cursors.Hand;
                };
            cfgBR(this.btnAgregar, "▶ Agregar",  0,  System.Drawing.Color.FromArgb(0, 140, 70));
            cfgBR(this.btnQuitar,  "◀ Quitar",   38, System.Drawing.Color.FromArgb(190, 50, 50));
            cfgBR(this.btnSubir,   "↑ Subir",    80, System.Drawing.Color.FromArgb(0, 100, 160));
            cfgBR(this.btnBajar,   "↓ Bajar",    118, System.Drawing.Color.FromArgb(0, 100, 160));

            this.btnAgregar.Name = "btnAgregar"; this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnQuitar.Name  = "btnQuitar";  this.btnQuitar.Click  += new System.EventHandler(this.btnQuitar_Click);
            this.btnSubir.Name   = "btnSubir";   this.btnSubir.Click   += new System.EventHandler(this.btnSubir_Click);
            this.btnBajar.Name   = "btnBajar";   this.btnBajar.Click   += new System.EventHandler(this.btnBajar_Click);

            // grpRutina
            this.grpRutina.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpRutina.Location = new System.Drawing.Point(540, 0);
            this.grpRutina.Name     = "grpRutina";
            this.grpRutina.Size     = new System.Drawing.Size(420, 225);
            this.grpRutina.Text     = "Ejercicios en la rutina (en orden)";
            this.grpRutina.Controls.Add(this.lstRutina);

            this.lstRutina.Font              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstRutina.FormattingEnabled = true;
            this.lstRutina.ItemHeight        = 20;
            this.lstRutina.Location          = new System.Drawing.Point(8, 20);
            this.lstRutina.Name              = "lstRutina";
            this.lstRutina.Size              = new System.Drawing.Size(404, 196);
            this.lstRutina.DisplayMember     = "TextoEnRutina";

            // ── UcConfigPausas ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll          = true;
            this.Controls.Add(this.lblModuloTitulo);
            this.Controls.Add(this.separadorTop);
            this.Controls.Add(this.grpConfigs);
            this.Controls.Add(this.grpParametros);
            this.Controls.Add(this.separadorMid);
            this.Controls.Add(this.lblRutinaTitulo);
            this.Controls.Add(this.lblDuracionTotal);
            this.Controls.Add(this.panelRutina);
            this.MinimumSize = new System.Drawing.Size(980, 600);
            this.Name        = "UcConfigPausas";
            this.Load       += new System.EventHandler(this.UcConfigPausas_Load);

            this.grpConfigs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfiguraciones)).EndInit();
            this.panelBotonesConfig.ResumeLayout(false);
            this.grpParametros.ResumeLayout(false);
            this.panelParametros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosPosponer)).EndInit();
            this.panelRutina.ResumeLayout(false);
            this.grpDisponibles.ResumeLayout(false);
            this.grpRutina.ResumeLayout(false);
            this.panelBotonesRutina.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label           lblModuloTitulo;
        private System.Windows.Forms.Label           separadorTop;
        private System.Windows.Forms.GroupBox        grpConfigs;
        private System.Windows.Forms.DataGridView    dgvConfiguraciones;
        private System.Windows.Forms.Panel           panelBotonesConfig;
        private System.Windows.Forms.Button          btnNuevaConfig;
        private System.Windows.Forms.Button          btnActivarConfig;
        private System.Windows.Forms.Button          btnEliminarConfig;
        private System.Windows.Forms.GroupBox        grpParametros;
        private System.Windows.Forms.Panel           panelParametros;
        private System.Windows.Forms.Label           lblTituloParametros;
        private System.Windows.Forms.Label           lblIntervalo;
        private System.Windows.Forms.NumericUpDown   nudIntervalo;
        private System.Windows.Forms.Label           lblMinutos;
        private System.Windows.Forms.Label           lblHoraInicio;
        private System.Windows.Forms.DateTimePicker  dtpHoraInicio;
        private System.Windows.Forms.Label           lblHoraFin;
        private System.Windows.Forms.DateTimePicker  dtpHoraFin;
        private System.Windows.Forms.CheckBox        chkPermitirPosponer;
        private System.Windows.Forms.Label           lblMinutosPosponer;
        private System.Windows.Forms.NumericUpDown   nudMinutosPosponer;
        private System.Windows.Forms.Label           lblMinPosLabel;
        private System.Windows.Forms.Button          btnGuardarConfig;
        private System.Windows.Forms.Label           separadorMid;
        private System.Windows.Forms.Label           lblRutinaTitulo;
        private System.Windows.Forms.Label           lblDuracionTotal;
        private System.Windows.Forms.Panel           panelRutina;
        private System.Windows.Forms.GroupBox        grpDisponibles;
        private System.Windows.Forms.ListBox         lstDisponibles;
        private System.Windows.Forms.Panel           panelBotonesRutina;
        private System.Windows.Forms.Button          btnAgregar;
        private System.Windows.Forms.Button          btnQuitar;
        private System.Windows.Forms.Button          btnSubir;
        private System.Windows.Forms.Button          btnBajar;
        private System.Windows.Forms.GroupBox        grpRutina;
        private System.Windows.Forms.ListBox         lstRutina;
    }
}
