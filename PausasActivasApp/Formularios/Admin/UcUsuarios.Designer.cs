namespace PausasActivasApp.Formularios.Admin
{
    partial class UcUsuarios
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
            this.panelToolbar       = new System.Windows.Forms.Panel();
            this.lblTituloModulo    = new System.Windows.Forms.Label();
            this.btnNuevo           = new System.Windows.Forms.Button();
            this.btnEditar          = new System.Windows.Forms.Button();
            this.btnRestablecerPass = new System.Windows.Forms.Button();
            this.btnCambiarEstado   = new System.Windows.Forms.Button();
            this.btnRefrescar       = new System.Windows.Forms.Button();
            this.dgvUsuarios        = new System.Windows.Forms.DataGridView();

            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // ── panelToolbar ────────────────────────────────────────────────
            this.panelToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.panelToolbar.Controls.Add(this.lblTituloModulo);
            this.panelToolbar.Controls.Add(this.btnNuevo);
            this.panelToolbar.Controls.Add(this.btnEditar);
            this.panelToolbar.Controls.Add(this.btnRestablecerPass);
            this.panelToolbar.Controls.Add(this.btnCambiarEstado);
            this.panelToolbar.Controls.Add(this.btnRefrescar);
            this.panelToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Height    = 90;
            this.panelToolbar.Name      = "panelToolbar";
            this.panelToolbar.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);

            // ── lblTituloModulo ─────────────────────────────────────────────
            this.lblTituloModulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTituloModulo.Location  = new System.Drawing.Point(10, 8);
            this.lblTituloModulo.Name      = "lblTituloModulo";
            this.lblTituloModulo.Size      = new System.Drawing.Size(350, 30);
            this.lblTituloModulo.Text      = "👥  Gestión de Empleados y Usuarios";

            // ── Helper para botones ─────────────────────────────────────────
            System.Action<System.Windows.Forms.Button, string, int, int, System.Drawing.Color> cfgBtn =
                (b, txt, left, width, color) =>
                {
                    b.BackColor   = color;
                    b.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Font        = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    b.ForeColor   = System.Drawing.Color.White;
                    b.Location    = new System.Drawing.Point(left, 48);
                    b.Size        = new System.Drawing.Size(width, 32);
                    b.Text        = txt;
                    b.Cursor      = System.Windows.Forms.Cursors.Hand;
                };

            cfgBtn(this.btnNuevo,           "➕ Nuevo Usuario",        10,  140, System.Drawing.Color.FromArgb(0, 140, 70));
            cfgBtn(this.btnEditar,          "✏ Editar",                158, 100, System.Drawing.Color.FromArgb(0, 100, 160));
            cfgBtn(this.btnRestablecerPass, "🔑 Restablecer Pass",     266, 150, System.Drawing.Color.FromArgb(110, 70, 160));
            cfgBtn(this.btnCambiarEstado,   "⏸ Activar/Desactivar",    424, 150, System.Drawing.Color.FromArgb(130, 100, 0));
            cfgBtn(this.btnRefrescar,       "🔄 Refrescar",             582, 110, System.Drawing.Color.FromArgb(80, 80, 80));

            this.btnNuevo.Name           = "btnNuevo";
            this.btnEditar.Name          = "btnEditar";
            this.btnRestablecerPass.Name = "btnRestablecerPass";
            this.btnCambiarEstado.Name   = "btnCambiarEstado";
            this.btnRefrescar.Name       = "btnRefrescar";

            this.btnNuevo.Click           += new System.EventHandler(this.btnNuevo_Click);
            this.btnEditar.Click          += new System.EventHandler(this.btnEditar_Click);
            this.btnRestablecerPass.Click += new System.EventHandler(this.btnRestablecerPass_Click);
            this.btnCambiarEstado.Click   += new System.EventHandler(this.btnCambiarEstado_Click);
            this.btnRefrescar.Click       += new System.EventHandler(this.btnRefrescar_Click);

            // ── dgvUsuarios ─────────────────────────────────────────────────
            this.dgvUsuarios.AllowUserToAddRows        = false;
            this.dgvUsuarios.AllowUserToDeleteRows     = false;
            this.dgvUsuarios.BackgroundColor           = System.Drawing.SystemColors.Window;
            this.dgvUsuarios.BorderStyle               = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle           = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Dock                      = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.GridColor                 = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvUsuarios.MultiSelect               = false;
            this.dgvUsuarios.Name                      = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly                  = true;
            this.dgvUsuarios.RowHeadersVisible         = false;
            this.dgvUsuarios.RowTemplate.Height        = 32;
            this.dgvUsuarios.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Font                      = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvUsuarios.SelectionChanged         += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            this.dgvUsuarios.CellDoubleClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);

            // ── UcUsuarios ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.panelToolbar);
            this.Name                = "UcUsuarios";
            this.Load               += new System.EventHandler(this.UcUsuarios_Load);

            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel           panelToolbar;
        private System.Windows.Forms.Label           lblTituloModulo;
        private System.Windows.Forms.Button          btnNuevo;
        private System.Windows.Forms.Button          btnEditar;
        private System.Windows.Forms.Button          btnRestablecerPass;
        private System.Windows.Forms.Button          btnCambiarEstado;
        private System.Windows.Forms.Button          btnRefrescar;
        private System.Windows.Forms.DataGridView    dgvUsuarios;
    }
}
