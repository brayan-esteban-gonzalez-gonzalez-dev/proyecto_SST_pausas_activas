namespace PausasActivasApp.Formularios.Empleado
{
    partial class FrmEmpleadoBandeja
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
            this.components              = new System.ComponentModel.Container();
            this.notifyIconEmpleado      = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuBandeja       = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemProximaPausa         = new System.Windows.Forms.ToolStripMenuItem();
            this.itemIniciarAhora         = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1      = new System.Windows.Forms.ToolStripSeparator();
            this.itemUsuario              = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCerrarSesion         = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSalir                = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCuentaRegresiva     = new System.Windows.Forms.Timer(this.components);
            this.timerSyncBD              = new System.Windows.Forms.Timer(this.components);

            this.contextMenuBandeja.SuspendLayout();
            this.SuspendLayout();

            // ── notifyIconEmpleado ──────────────────────────────────────────
            this.notifyIconEmpleado.ContextMenuStrip = this.contextMenuBandeja;
            this.notifyIconEmpleado.DoubleClick     += new System.EventHandler(this.notifyIconEmpleado_DoubleClick);

            // ── contextMenuBandeja ──────────────────────────────────────────
            this.contextMenuBandeja.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.contextMenuBandeja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.itemProximaPausa,
                this.itemIniciarAhora,
                this.toolStripSeparator1,
                this.itemUsuario,
                this.itemCerrarSesion,
                this.itemSalir
            });
            this.contextMenuBandeja.Name = "contextMenuBandeja";
            this.contextMenuBandeja.Size = new System.Drawing.Size(250, 142);

            // itemProximaPausa
            this.itemProximaPausa.Enabled   = false;
            this.itemProximaPausa.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.itemProximaPausa.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.itemProximaPausa.Name      = "itemProximaPausa";
            this.itemProximaPausa.Size      = new System.Drawing.Size(249, 22);
            this.itemProximaPausa.Text      = "⏱ Próxima pausa: --:--";

            // itemIniciarAhora
            this.itemIniciarAhora.Name  = "itemIniciarAhora";
            this.itemIniciarAhora.Size  = new System.Drawing.Size(249, 22);
            this.itemIniciarAhora.Text  = "▶ Iniciar pausa activa ahora";
            this.itemIniciarAhora.Click += new System.EventHandler(this.itemIniciarAhora_Click);

            // toolStripSeparator1
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);

            // itemUsuario
            this.itemUsuario.Enabled = false;
            this.itemUsuario.Name    = "itemUsuario";
            this.itemUsuario.Size    = new System.Drawing.Size(249, 22);
            this.itemUsuario.Text    = "👤 Sesión: ...";

            // itemCerrarSesion
            this.itemCerrarSesion.Name  = "itemCerrarSesion";
            this.itemCerrarSesion.Size  = new System.Drawing.Size(249, 22);
            this.itemCerrarSesion.Text  = "🚪 Cerrar sesión";
            this.itemCerrarSesion.Click += new System.EventHandler(this.itemCerrarSesion_Click);

            // itemSalir
            this.itemSalir.ForeColor = System.Drawing.Color.Firebrick;
            this.itemSalir.Name      = "itemSalir";
            this.itemSalir.Size      = new System.Drawing.Size(249, 22);
            this.itemSalir.Text      = "❌ Salir de la aplicación";
            this.itemSalir.Click     += new System.EventHandler(this.itemSalir_Click);

            // ── timerCuentaRegresiva ────────────────────────────────────────
            this.timerCuentaRegresiva.Interval = 1000;
            this.timerCuentaRegresiva.Tick    += new System.EventHandler(this.timerCuentaRegresiva_Tick);

            // ── timerSyncBD (60 segundos) ───────────────────────────────────
            this.timerSyncBD.Interval = 60000;
            this.timerSyncBD.Tick    += new System.EventHandler(this.timerSyncBD_Tick);

            // ── FrmEmpleadoBandeja ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(280, 150);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FrmEmpleadoBandeja";
            this.ShowInTaskbar       = false;
            this.Text                = "Pausas Activas — Empleado";
            this.WindowState         = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.FrmEmpleadoBandeja_FormClosing);
            this.Load               += new System.EventHandler(this.FrmEmpleadoBandeja_Load);

            this.contextMenuBandeja.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.NotifyIcon           notifyIconEmpleado;
        private System.Windows.Forms.ContextMenuStrip      contextMenuBandeja;
        private System.Windows.Forms.ToolStripMenuItem     itemProximaPausa;
        private System.Windows.Forms.ToolStripMenuItem     itemIniciarAhora;
        private System.Windows.Forms.ToolStripSeparator    toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem     itemUsuario;
        private System.Windows.Forms.ToolStripMenuItem     itemCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem     itemSalir;
        private System.Windows.Forms.Timer                 timerCuentaRegresiva;
        private System.Windows.Forms.Timer                 timerSyncBD;
    }
}
