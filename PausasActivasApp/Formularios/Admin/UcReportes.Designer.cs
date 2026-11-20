namespace PausasActivasApp.Formularios.Admin
{
    partial class UcReportes
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
            this.panelHeader            = new System.Windows.Forms.Panel();
            this.lblTituloModulo        = new System.Windows.Forms.Label();
            this.panelFiltros           = new System.Windows.Forms.Panel();
            this.lblDesde               = new System.Windows.Forms.Label();
            this.dtpDesde               = new System.Windows.Forms.DateTimePicker();
            this.lblHasta               = new System.Windows.Forms.Label();
            this.dtpHasta               = new System.Windows.Forms.DateTimePicker();
            this.lblUsuario             = new System.Windows.Forms.Label();
            this.cmbUsuario             = new System.Windows.Forms.ComboBox();
            this.lblEstado              = new System.Windows.Forms.Label();
            this.cmbEstado              = new System.Windows.Forms.ComboBox();
            this.btnFiltrar             = new System.Windows.Forms.Button();
            this.btnLimpiar             = new System.Windows.Forms.Button();
            this.btnExportarCSV         = new System.Windows.Forms.Button();
            this.panelMetricas          = new System.Windows.Forms.Panel();
            this.pnlCardTotal           = new System.Windows.Forms.Panel();
            this.lblTituloCardTotal     = new System.Windows.Forms.Label();
            this.lblMetricaTotal        = new System.Windows.Forms.Label();
            this.pnlCardCompletadas     = new System.Windows.Forms.Panel();
            this.lblTituloCardComp      = new System.Windows.Forms.Label();
            this.lblMetricaCompletadas  = new System.Windows.Forms.Label();
            this.pnlCardPospuestas      = new System.Windows.Forms.Panel();
            this.lblTituloCardPosp      = new System.Windows.Forms.Label();
            this.lblMetricaPospuestas   = new System.Windows.Forms.Label();
            this.pnlCardOmitidas        = new System.Windows.Forms.Panel();
            this.lblTituloCardOmit      = new System.Windows.Forms.Label();
            this.lblMetricaOmitidas     = new System.Windows.Forms.Label();
            this.pnlCardTiempo          = new System.Windows.Forms.Panel();
            this.lblTituloCardTiempo    = new System.Windows.Forms.Label();
            this.lblMetricaTiempo       = new System.Windows.Forms.Label();
            this.dgvReportes            = new System.Windows.Forms.DataGridView();

            this.panelHeader.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelMetricas.SuspendLayout();
            this.pnlCardTotal.SuspendLayout();
            this.pnlCardCompletadas.SuspendLayout();
            this.pnlCardPospuestas.SuspendLayout();
            this.pnlCardOmitidas.SuspendLayout();
            this.pnlCardTiempo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();

            // ── panelHeader ─────────────────────────────────────────────────
            this.panelHeader.Controls.Add(this.lblTituloModulo);
            this.panelHeader.Dock    = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height  = 38;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name    = "panelHeader";

            // lblTituloModulo
            this.lblTituloModulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTituloModulo.Location  = new System.Drawing.Point(10, 6);
            this.lblTituloModulo.Name      = "lblTituloModulo";
            this.lblTituloModulo.Size      = new System.Drawing.Size(450, 26);
            this.lblTituloModulo.Text      = "📊  Reportes y Cumplimiento de Pausas Activas";

            // ── panelFiltros ────────────────────────────────────────────────
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblUsuario);
            this.panelFiltros.Controls.Add(this.cmbUsuario);
            this.panelFiltros.Controls.Add(this.lblEstado);
            this.panelFiltros.Controls.Add(this.cmbEstado);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.btnLimpiar);
            this.panelFiltros.Controls.Add(this.btnExportarCSV);
            this.panelFiltros.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height    = 66;
            this.panelFiltros.Location  = new System.Drawing.Point(0, 38);
            this.panelFiltros.Name      = "panelFiltros";

            // lblDesde / dtpDesde
            this.lblDesde.Font     = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDesde.Location = new System.Drawing.Point(10, 8);
            this.lblDesde.Name     = "lblDesde";
            this.lblDesde.Size     = new System.Drawing.Size(100, 16);
            this.lblDesde.Text     = "Desde:";

            this.dtpDesde.Font   = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(10, 28);
            this.dtpDesde.Name   = "dtpDesde";
            this.dtpDesde.Size   = new System.Drawing.Size(100, 23);

            // lblHasta / dtpHasta
            this.lblHasta.Font     = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHasta.Location = new System.Drawing.Point(120, 8);
            this.lblHasta.Name     = "lblHasta";
            this.lblHasta.Size     = new System.Drawing.Size(100, 16);
            this.lblHasta.Text     = "Hasta:";

            this.dtpHasta.Font   = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(120, 28);
            this.dtpHasta.Name   = "dtpHasta";
            this.dtpHasta.Size   = new System.Drawing.Size(100, 23);

            // lblUsuario / cmbUsuario
            this.lblUsuario.Font     = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(232, 8);
            this.lblUsuario.Name     = "lblUsuario";
            this.lblUsuario.Size     = new System.Drawing.Size(160, 16);
            this.lblUsuario.Text     = "Empleado:";

            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUsuario.Location      = new System.Drawing.Point(232, 28);
            this.cmbUsuario.Name          = "cmbUsuario";
            this.cmbUsuario.Size          = new System.Drawing.Size(160, 23);

            // lblEstado / cmbEstado
            this.lblEstado.Font     = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(402, 8);
            this.lblEstado.Name     = "lblEstado";
            this.lblEstado.Size     = new System.Drawing.Size(120, 16);
            this.lblEstado.Text     = "Estado:";

            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstado.Location      = new System.Drawing.Point(402, 28);
            this.cmbEstado.Name          = "cmbEstado";
            this.cmbEstado.Size          = new System.Drawing.Size(120, 23);

            // btnFiltrar
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location  = new System.Drawing.Point(535, 23);
            this.btnFiltrar.Name      = "btnFiltrar";
            this.btnFiltrar.Size      = new System.Drawing.Size(95, 30);
            this.btnFiltrar.Text      = "🔍 Filtrar";
            this.btnFiltrar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click    += new System.EventHandler(this.btnFiltrar_Click);

            // btnLimpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location  = new System.Drawing.Point(636, 23);
            this.btnLimpiar.Name      = "btnLimpiar";
            this.btnLimpiar.Size      = new System.Drawing.Size(90, 30);
            this.btnLimpiar.Text      = "🔄 Limpiar";
            this.btnLimpiar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click    += new System.EventHandler(this.btnLimpiar_Click);

            // btnExportarCSV
            this.btnExportarCSV.BackColor = System.Drawing.Color.FromArgb(0, 140, 70);
            this.btnExportarCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarCSV.FlatAppearance.BorderSize = 0;
            this.btnExportarCSV.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportarCSV.Location  = new System.Drawing.Point(740, 23);
            this.btnExportarCSV.Name      = "btnExportarCSV";
            this.btnExportarCSV.Size      = new System.Drawing.Size(140, 30);
            this.btnExportarCSV.Text      = "📥 Exportar CSV";
            this.btnExportarCSV.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnExportarCSV.Click    += new System.EventHandler(this.btnExportarCSV_Click);

            // ── panelMetricas (Tarjetas de métricas estadísticas) ───────────
            this.panelMetricas.Controls.Add(this.pnlCardTotal);
            this.panelMetricas.Controls.Add(this.pnlCardCompletadas);
            this.panelMetricas.Controls.Add(this.pnlCardPospuestas);
            this.panelMetricas.Controls.Add(this.pnlCardOmitidas);
            this.panelMetricas.Controls.Add(this.pnlCardTiempo);
            this.panelMetricas.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelMetricas.Height    = 75;
            this.panelMetricas.Location  = new System.Drawing.Point(0, 104);
            this.panelMetricas.Name      = "panelMetricas";
            this.panelMetricas.Padding   = new System.Windows.Forms.Padding(0, 8, 0, 8);

            // Helper para configurar paneles de tarjeta
            System.Action<System.Windows.Forms.Panel, System.Windows.Forms.Label, System.Windows.Forms.Label, string, System.Drawing.Color, int> cfgCard =
                (pnl, lblTit, lblVal, titulo, color, x) =>
                {
                    pnl.BackColor   = System.Drawing.Color.White;
                    pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pnl.Location    = new System.Drawing.Point(x, 8);
                    pnl.Size        = new System.Drawing.Size(170, 58);

                    lblTit.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
                    lblTit.ForeColor = System.Drawing.Color.Gray;
                    lblTit.Location  = new System.Drawing.Point(5, 5);
                    lblTit.Size      = new System.Drawing.Size(160, 16);
                    lblTit.Text      = titulo;

                    lblVal.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
                    lblVal.ForeColor = color;
                    lblVal.Location  = new System.Drawing.Point(5, 23);
                    lblVal.Size      = new System.Drawing.Size(160, 26);
                    lblVal.Text      = "0";
                    lblVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                };

            cfgCard(this.pnlCardTotal,        this.lblTituloCardTotal,  this.lblMetricaTotal,        "TOTAL PAUSAS",     System.Drawing.Color.FromArgb(45, 45, 68),  10);
            cfgCard(this.pnlCardCompletadas,  this.lblTituloCardComp,   this.lblMetricaCompletadas,  "COMPLETADAS",      System.Drawing.Color.FromArgb(0, 140, 70),  190);
            cfgCard(this.pnlCardPospuestas,   this.lblTituloCardPosp,   this.lblMetricaPospuestas,   "POSPUESTAS",       System.Drawing.Color.FromArgb(200, 120, 0),  370);
            cfgCard(this.pnlCardOmitidas,     this.lblTituloCardOmit,   this.lblMetricaOmitidas,     "OMITIDAS",         System.Drawing.Color.FromArgb(190, 50, 50),  550);
            cfgCard(this.pnlCardTiempo,       this.lblTituloCardTiempo, this.lblMetricaTiempo,       "TIEMPO INVERTIDO", System.Drawing.Color.FromArgb(0, 100, 160), 730);

            // ── dgvReportes ─────────────────────────────────────────────────
            this.dgvReportes.AllowUserToAddRows        = false;
            this.dgvReportes.AllowUserToDeleteRows     = false;
            this.dgvReportes.BackgroundColor           = System.Drawing.SystemColors.Window;
            this.dgvReportes.BorderStyle               = System.Windows.Forms.BorderStyle.None;
            this.dgvReportes.CellBorderStyle           = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Dock                      = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportes.GridColor                 = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvReportes.Location                  = new System.Drawing.Point(0, 179);
            this.dgvReportes.MultiSelect               = false;
            this.dgvReportes.Name                      = "dgvReportes";
            this.dgvReportes.ReadOnly                  = true;
            this.dgvReportes.RowHeadersVisible         = false;
            this.dgvReportes.RowTemplate.Height        = 30;
            this.dgvReportes.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Font                      = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvReportes.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // ── UcReportes ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.panelMetricas);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelHeader);
            this.Name                = "UcReportes";
            this.Size                = new System.Drawing.Size(920, 560);
            this.Load               += new System.EventHandler(this.UcReportes_Load);

            this.panelHeader.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelMetricas.ResumeLayout(false);
            this.pnlCardTotal.ResumeLayout(false);
            this.pnlCardCompletadas.ResumeLayout(false);
            this.pnlCardPospuestas.ResumeLayout(false);
            this.pnlCardOmitidas.ResumeLayout(false);
            this.pnlCardTiempo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel           panelHeader;
        private System.Windows.Forms.Label           lblTituloModulo;
        private System.Windows.Forms.Panel           panelFiltros;
        private System.Windows.Forms.Label           lblDesde;
        private System.Windows.Forms.DateTimePicker  dtpDesde;
        private System.Windows.Forms.Label           lblHasta;
        private System.Windows.Forms.DateTimePicker  dtpHasta;
        private System.Windows.Forms.Label           lblUsuario;
        private System.Windows.Forms.ComboBox        cmbUsuario;
        private System.Windows.Forms.Label           lblEstado;
        private System.Windows.Forms.ComboBox        cmbEstado;
        private System.Windows.Forms.Button          btnFiltrar;
        private System.Windows.Forms.Button          btnLimpiar;
        private System.Windows.Forms.Button          btnExportarCSV;
        private System.Windows.Forms.Panel           panelMetricas;
        private System.Windows.Forms.Panel           pnlCardTotal;
        private System.Windows.Forms.Label           lblTituloCardTotal;
        private System.Windows.Forms.Label           lblMetricaTotal;
        private System.Windows.Forms.Panel           pnlCardCompletadas;
        private System.Windows.Forms.Label           lblTituloCardComp;
        private System.Windows.Forms.Label           lblMetricaCompletadas;
        private System.Windows.Forms.Panel           pnlCardPospuestas;
        private System.Windows.Forms.Label           lblTituloCardPosp;
        private System.Windows.Forms.Label           lblMetricaPospuestas;
        private System.Windows.Forms.Panel           pnlCardOmitidas;
        private System.Windows.Forms.Label           lblTituloCardOmit;
        private System.Windows.Forms.Label           lblMetricaOmitidas;
        private System.Windows.Forms.Panel           pnlCardTiempo;
        private System.Windows.Forms.Label           lblTituloCardTiempo;
        private System.Windows.Forms.Label           lblMetricaTiempo;
        private System.Windows.Forms.DataGridView    dgvReportes;
    }
}
