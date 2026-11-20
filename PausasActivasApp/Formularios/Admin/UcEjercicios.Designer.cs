namespace PausasActivasApp.Formularios.Admin
{
    partial class UcEjercicios
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
            this.panelToolbar      = new System.Windows.Forms.Panel();
            this.lblTituloModulo   = new System.Windows.Forms.Label();
            this.btnNuevo          = new System.Windows.Forms.Button();
            this.btnEditar         = new System.Windows.Forms.Button();
            this.btnEliminar       = new System.Windows.Forms.Button();
            this.btnCambiarEstado  = new System.Windows.Forms.Button();
            this.btnRefrescar      = new System.Windows.Forms.Button();
            this.dgvEjercicios     = new System.Windows.Forms.DataGridView();

            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).BeginInit();
            this.SuspendLayout();

            // ── panelToolbar ────────────────────────────────────────────────
            this.panelToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.panelToolbar.Controls.Add(this.lblTituloModulo);
            this.panelToolbar.Controls.Add(this.btnNuevo);
            this.panelToolbar.Controls.Add(this.btnEditar);
            this.panelToolbar.Controls.Add(this.btnEliminar);
            this.panelToolbar.Controls.Add(this.btnCambiarEstado);
            this.panelToolbar.Controls.Add(this.btnRefrescar);
            this.panelToolbar.Dock     = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Height   = 90;
            this.panelToolbar.Name     = "panelToolbar";
            this.panelToolbar.Padding  = new System.Windows.Forms.Padding(10, 8, 10, 8);

            // ── lblTituloModulo ─────────────────────────────────────────────
            this.lblTituloModulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTituloModulo.Location  = new System.Drawing.Point(10, 8);
            this.lblTituloModulo.Name      = "lblTituloModulo";
            this.lblTituloModulo.Size      = new System.Drawing.Size(300, 30);
            this.lblTituloModulo.Text      = "🏋  Gestión de Ejercicios";

            // ── Helper para crear botones de toolbar ────────────────────────
            System.Action<System.Windows.Forms.Button, string, int, System.Drawing.Color> cfgBtn =
                (b, txt, left, color) =>
                {
                    b.BackColor   = color;
                    b.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Font        = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    b.ForeColor   = System.Drawing.Color.White;
                    b.Location    = new System.Drawing.Point(left, 48);
                    b.Size        = new System.Drawing.Size(130, 32);
                    b.Text        = txt;
                    b.Cursor      = System.Windows.Forms.Cursors.Hand;
                };

            cfgBtn(this.btnNuevo,         "➕ Nuevo",             10,  System.Drawing.Color.FromArgb(0, 140, 70));
            cfgBtn(this.btnEditar,        "✏ Editar",             148, System.Drawing.Color.FromArgb(0, 100, 160));
            cfgBtn(this.btnEliminar,      "🗑 Eliminar",           286, System.Drawing.Color.FromArgb(190, 50, 50));
            cfgBtn(this.btnCambiarEstado, "⏸ Activar/Desactivar", 424, System.Drawing.Color.FromArgb(130, 100, 0));
            cfgBtn(this.btnRefrescar,     "🔄 Refrescar",          562, System.Drawing.Color.FromArgb(80, 80, 80));

            this.btnNuevo.Name         = "btnNuevo";
            this.btnEditar.Name        = "btnEditar";
            this.btnEliminar.Name      = "btnEliminar";
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnRefrescar.Name     = "btnRefrescar";

            this.btnNuevo.Click        += new System.EventHandler(this.btnNuevo_Click);
            this.btnEditar.Click       += new System.EventHandler(this.btnEditar_Click);
            this.btnEliminar.Click     += new System.EventHandler(this.btnEliminar_Click);
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            this.btnRefrescar.Click    += new System.EventHandler(this.btnRefrescar_Click);

            // ── dgvEjercicios ───────────────────────────────────────────────
            this.dgvEjercicios.AllowUserToAddRows        = false;
            this.dgvEjercicios.AllowUserToDeleteRows     = false;
            this.dgvEjercicios.AutoSizeColumnsMode       = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvEjercicios.BackgroundColor           = System.Drawing.SystemColors.Window;
            this.dgvEjercicios.BorderStyle               = System.Windows.Forms.BorderStyle.None;
            this.dgvEjercicios.CellBorderStyle           = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEjercicios.Dock                      = System.Windows.Forms.DockStyle.Fill;
            this.dgvEjercicios.GridColor                 = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvEjercicios.MultiSelect               = false;
            this.dgvEjercicios.Name                      = "dgvEjercicios";
            this.dgvEjercicios.ReadOnly                  = true;
            this.dgvEjercicios.RowHeadersVisible         = false;
            this.dgvEjercicios.RowTemplate.Height        = 32;
            this.dgvEjercicios.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEjercicios.Font                      = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvEjercicios.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvEjercicios.SelectionChanged    += new System.EventHandler(this.dgvEjercicios_SelectionChanged);
            this.dgvEjercicios.CellDoubleClick     += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEjercicios_CellDoubleClick);

            // ── UcEjercicios ────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvEjercicios);
            this.Controls.Add(this.panelToolbar);
            this.Name                = "UcEjercicios";
            this.Load               += new System.EventHandler(this.UcEjercicios_Load);

            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel           panelToolbar;
        private System.Windows.Forms.Label           lblTituloModulo;
        private System.Windows.Forms.Button          btnNuevo;
        private System.Windows.Forms.Button          btnEditar;
        private System.Windows.Forms.Button          btnEliminar;
        private System.Windows.Forms.Button          btnCambiarEstado;
        private System.Windows.Forms.Button          btnRefrescar;
        private System.Windows.Forms.DataGridView    dgvEjercicios;
    }
}
