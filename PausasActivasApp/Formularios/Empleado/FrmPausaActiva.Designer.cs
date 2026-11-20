namespace PausasActivasApp.Formularios.Empleado
{
    partial class FrmPausaActiva
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
            this.components            = new System.ComponentModel.Container();
            this.timerEjercicio        = new System.Windows.Forms.Timer(this.components);
            this.panelTop              = new System.Windows.Forms.Panel();
            this.lblHeader             = new System.Windows.Forms.Label();
            this.lblEjercicioNum       = new System.Windows.Forms.Label();
            this.pbTotal               = new System.Windows.Forms.ProgressBar();
            this.panelContenido        = new System.Windows.Forms.Panel();
            this.panelIzquierdo        = new System.Windows.Forms.Panel();
            this.lblTituloEjercicio    = new System.Windows.Forms.Label();
            this.lblInstrucciones      = new System.Windows.Forms.Label();
            this.txtDescripcion        = new System.Windows.Forms.TextBox();
            this.panelTiempo           = new System.Windows.Forms.Panel();
            this.lblTiempoHeader       = new System.Windows.Forms.Label();
            this.lblTiempo             = new System.Windows.Forms.Label();
            this.pbEjercicio           = new System.Windows.Forms.ProgressBar();
            this.panelDerecho          = new System.Windows.Forms.Panel();
            this.picEjercicio          = new System.Windows.Forms.PictureBox();
            this.panelBottom           = new System.Windows.Forms.Panel();
            this.btnPosponer           = new System.Windows.Forms.Button();
            this.btnSiguiente          = new System.Windows.Forms.Button();
            this.btnOmitir             = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            this.panelTiempo.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEjercicio)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── timerEjercicio ──────────────────────────────────────────────
            this.timerEjercicio.Interval = 1000;
            this.timerEjercicio.Tick    += new System.EventHandler(this.timerEjercicio_Tick);

            // ── panelTop ────────────────────────────────────────────────────
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.panelTop.Controls.Add(this.lblHeader);
            this.panelTop.Controls.Add(this.lblEjercicioNum);
            this.panelTop.Controls.Add(this.pbTotal);
            this.panelTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height    = 75;
            this.panelTop.Name      = "panelTop";
            this.panelTop.Padding   = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblHeader
            this.lblHeader.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location  = new System.Drawing.Point(20, 10);
            this.lblHeader.Name      = "lblHeader";
            this.lblHeader.Size      = new System.Drawing.Size(400, 26);
            this.lblHeader.Text      = "⏸  PAUSA ACTIVA EN CURSO";

            // lblEjercicioNum
            this.lblEjercicioNum.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEjercicioNum.ForeColor = System.Drawing.Color.FromArgb(200, 230, 255);
            this.lblEjercicioNum.Location  = new System.Drawing.Point(600, 12);
            this.lblEjercicioNum.Name      = "lblEjercicioNum";
            this.lblEjercicioNum.Size      = new System.Drawing.Size(200, 22);
            this.lblEjercicioNum.Text      = "Ejercicio 1 de 3";
            this.lblEjercicioNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pbTotal
            this.pbTotal.Location = new System.Drawing.Point(20, 42);
            this.pbTotal.Name     = "pbTotal";
            this.pbTotal.Size     = new System.Drawing.Size(780, 18);

            // ── panelContenido ──────────────────────────────────────────────
            this.panelContenido.Controls.Add(this.panelIzquierdo);
            this.panelContenido.Controls.Add(this.panelDerecho);
            this.panelContenido.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 75);
            this.panelContenido.Name     = "panelContenido";
            this.panelContenido.Padding  = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelContenido.Size     = new System.Drawing.Size(824, 425);

            // ── panelIzquierdo (Instrucciones + temporizador) ────────────────
            this.panelIzquierdo.Controls.Add(this.lblTituloEjercicio);
            this.panelIzquierdo.Controls.Add(this.lblInstrucciones);
            this.panelIzquierdo.Controls.Add(this.txtDescripcion);
            this.panelIzquierdo.Controls.Add(this.panelTiempo);
            this.panelIzquierdo.Dock     = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(20, 15);
            this.panelIzquierdo.Name     = "panelIzquierdo";
            this.panelIzquierdo.Size     = new System.Drawing.Size(440, 395);

            // lblTituloEjercicio
            this.lblTituloEjercicio.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloEjercicio.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTituloEjercicio.Location  = new System.Drawing.Point(0, 0);
            this.lblTituloEjercicio.Name      = "lblTituloEjercicio";
            this.lblTituloEjercicio.Size      = new System.Drawing.Size(430, 32);
            this.lblTituloEjercicio.Text      = "Título del Ejercicio";

            // lblInstrucciones
            this.lblInstrucciones.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInstrucciones.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblInstrucciones.Location  = new System.Drawing.Point(0, 36);
            this.lblInstrucciones.Name      = "lblInstrucciones";
            this.lblInstrucciones.Size      = new System.Drawing.Size(200, 20);
            this.lblInstrucciones.Text      = "Instrucciones paso a paso:";

            // txtDescripcion
            this.txtDescripcion.BackColor   = System.Drawing.SystemColors.Window;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location    = new System.Drawing.Point(0, 60);
            this.txtDescripcion.Multiline   = true;
            this.txtDescripcion.Name        = "txtDescripcion";
            this.txtDescripcion.ReadOnly    = true;
            this.txtDescripcion.ScrollBars   = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size        = new System.Drawing.Size(430, 210);

            // panelTiempo
            this.panelTiempo.BackColor   = System.Drawing.Color.FromArgb(245, 248, 252);
            this.panelTiempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTiempo.Controls.Add(this.lblTiempoHeader);
            this.panelTiempo.Controls.Add(this.lblTiempo);
            this.panelTiempo.Controls.Add(this.pbEjercicio);
            this.panelTiempo.Location    = new System.Drawing.Point(0, 282);
            this.panelTiempo.Name        = "panelTiempo";
            this.panelTiempo.Size        = new System.Drawing.Size(430, 105);

            // lblTiempoHeader
            this.lblTiempoHeader.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTiempoHeader.ForeColor = System.Drawing.Color.Gray;
            this.lblTiempoHeader.Location  = new System.Drawing.Point(10, 8);
            this.lblTiempoHeader.Name      = "lblTiempoHeader";
            this.lblTiempoHeader.Size      = new System.Drawing.Size(200, 18);
            this.lblTiempoHeader.Text      = "TIEMPO RESTANTE:";

            // lblTiempo
            this.lblTiempo.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTiempo.ForeColor = System.Drawing.Color.FromArgb(0, 120, 60);
            this.lblTiempo.Location  = new System.Drawing.Point(10, 26);
            this.lblTiempo.Name      = "lblTiempo";
            this.lblTiempo.Size      = new System.Drawing.Size(408, 48);
            this.lblTiempo.Text      = "00:20";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pbEjercicio
            this.pbEjercicio.Location = new System.Drawing.Point(10, 78);
            this.pbEjercicio.Name     = "pbEjercicio";
            this.pbEjercicio.Size     = new System.Drawing.Size(408, 14);

            // ── panelDerecho (Imagen o GIF animado) ─────────────────────────
            this.panelDerecho.Controls.Add(this.picEjercicio);
            this.panelDerecho.Dock     = System.Windows.Forms.DockStyle.Right;
            this.panelDerecho.Location = new System.Drawing.Point(474, 15);
            this.panelDerecho.Name     = "panelDerecho";
            this.panelDerecho.Size     = new System.Drawing.Size(330, 395);

            // picEjercicio
            this.picEjercicio.BackColor   = System.Drawing.Color.FromArgb(235, 235, 235);
            this.picEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEjercicio.Location    = new System.Drawing.Point(5, 5);
            this.picEjercicio.Name        = "picEjercicio";
            this.picEjercicio.Size        = new System.Drawing.Size(320, 382);
            this.picEjercicio.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // ── panelBottom (Acciones de la pausa) ───────────────────────────
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.btnPosponer);
            this.panelBottom.Controls.Add(this.btnSiguiente);
            this.panelBottom.Controls.Add(this.btnOmitir);
            this.panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height    = 60;
            this.panelBottom.Name      = "panelBottom";
            this.panelBottom.Padding   = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // btnPosponer
            this.btnPosponer.BackColor = System.Drawing.Color.FromArgb(200, 120, 0);
            this.btnPosponer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosponer.FlatAppearance.BorderSize = 0;
            this.btnPosponer.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPosponer.ForeColor = System.Drawing.Color.White;
            this.btnPosponer.Location  = new System.Drawing.Point(20, 12);
            this.btnPosponer.Name      = "btnPosponer";
            this.btnPosponer.Size      = new System.Drawing.Size(180, 36);
            this.btnPosponer.Text      = "⏸ Posponer (10 min)";
            this.btnPosponer.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnPosponer.Click    += new System.EventHandler(this.btnPosponer_Click);

            // btnSiguiente
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(0, 120, 60);
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location  = new System.Drawing.Point(470, 12);
            this.btnSiguiente.Name      = "btnSiguiente";
            this.btnSiguiente.Size      = new System.Drawing.Size(180, 36);
            this.btnSiguiente.Text      = "⏭ Siguiente Ejercicio";
            this.btnSiguiente.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.Click    += new System.EventHandler(this.btnSiguiente_Click);

            // btnOmitir
            this.btnOmitir.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnOmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOmitir.FlatAppearance.BorderSize = 0;
            this.btnOmitir.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnOmitir.ForeColor = System.Drawing.Color.White;
            this.btnOmitir.Location  = new System.Drawing.Point(660, 12);
            this.btnOmitir.Name      = "btnOmitir";
            this.btnOmitir.Size      = new System.Drawing.Size(140, 36);
            this.btnOmitir.Text      = "Omitir Pausa";
            this.btnOmitir.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnOmitir.Click    += new System.EventHandler(this.btnOmitir_Click);

            // ── FrmPausaActiva ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(824, 560);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FrmPausaActiva";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Pausa Activa Laboral";
            this.TopMost             = true;
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.FrmPausaActiva_FormClosing);
            this.Load               += new System.EventHandler(this.FrmPausaActiva_Load);

            this.panelTop.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            this.panelIzquierdo.PerformLayout();
            this.panelTiempo.ResumeLayout(false);
            this.panelDerecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEjercicio)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer       timerEjercicio;
        private System.Windows.Forms.Panel       panelTop;
        private System.Windows.Forms.Label       lblHeader;
        private System.Windows.Forms.Label       lblEjercicioNum;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.Panel       panelContenido;
        private System.Windows.Forms.Panel       panelIzquierdo;
        private System.Windows.Forms.Label       lblTituloEjercicio;
        private System.Windows.Forms.Label       lblInstrucciones;
        private System.Windows.Forms.TextBox     txtDescripcion;
        private System.Windows.Forms.Panel       panelTiempo;
        private System.Windows.Forms.Label       lblTiempoHeader;
        private System.Windows.Forms.Label       lblTiempo;
        private System.Windows.Forms.ProgressBar pbEjercicio;
        private System.Windows.Forms.Panel       panelDerecho;
        private System.Windows.Forms.PictureBox  picEjercicio;
        private System.Windows.Forms.Panel       panelBottom;
        private System.Windows.Forms.Button      btnPosponer;
        private System.Windows.Forms.Button      btnSiguiente;
        private System.Windows.Forms.Button      btnOmitir;
    }
}
