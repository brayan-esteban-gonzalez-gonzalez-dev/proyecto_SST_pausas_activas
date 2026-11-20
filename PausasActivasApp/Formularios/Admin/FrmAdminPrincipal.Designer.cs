namespace PausasActivasApp.Formularios.Admin
{
    partial class FrmAdminPrincipal
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
            this.panelSidebar      = new System.Windows.Forms.Panel();
            this.lblAppTitle       = new System.Windows.Forms.Label();
            this.lblUsuarioSesion  = new System.Windows.Forms.Label();
            this.separador1        = new System.Windows.Forms.Label();
            this.btnEjercicios     = new System.Windows.Forms.Button();
            this.btnConfigPausas   = new System.Windows.Forms.Button();
            this.btnEmpleados      = new System.Windows.Forms.Button();
            this.btnReportes       = new System.Windows.Forms.Button();
            this.panelBottom       = new System.Windows.Forms.Panel();
            this.btnCerrarSesion   = new System.Windows.Forms.Button();
            this.panelContenido    = new System.Windows.Forms.Panel();

            this.panelSidebar.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── panelSidebar ────────────────────────────────────────────────
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(45, 45, 68);
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Controls.Add(this.lblUsuarioSesion);
            this.panelSidebar.Controls.Add(this.separador1);
            this.panelSidebar.Controls.Add(this.btnEjercicios);
            this.panelSidebar.Controls.Add(this.btnConfigPausas);
            this.panelSidebar.Controls.Add(this.btnEmpleados);
            this.panelSidebar.Controls.Add(this.btnReportes);
            this.panelSidebar.Controls.Add(this.panelBottom);
            this.panelSidebar.Dock     = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Name     = "panelSidebar";
            this.panelSidebar.Width    = 185;

            // ── lblAppTitle ─────────────────────────────────────────────────
            this.lblAppTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location  = new System.Drawing.Point(0, 18);
            this.lblAppTitle.Name      = "lblAppTitle";
            this.lblAppTitle.Size      = new System.Drawing.Size(185, 30);
            this.lblAppTitle.Text      = "⏸ Pausas Activas";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblUsuarioSesion ────────────────────────────────────────────
            this.lblUsuarioSesion.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUsuarioSesion.ForeColor = System.Drawing.Color.FromArgb(170, 200, 220);
            this.lblUsuarioSesion.Location  = new System.Drawing.Point(0, 50);
            this.lblUsuarioSesion.Name      = "lblUsuarioSesion";
            this.lblUsuarioSesion.Size      = new System.Drawing.Size(185, 20);
            this.lblUsuarioSesion.Text      = "👤 Administrador";
            this.lblUsuarioSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── separador1 ──────────────────────────────────────────────────
            this.separador1.BackColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.separador1.Location  = new System.Drawing.Point(15, 80);
            this.separador1.Name      = "separador1";
            this.separador1.Size      = new System.Drawing.Size(155, 1);

            // ── Función helper para crear botones del sidebar ───────────────
            System.Action<System.Windows.Forms.Button, string, int> configurarBtn =
                (btn, texto, top) =>
                {
                    btn.BackColor   = System.Drawing.Color.FromArgb(45, 45, 68);
                    btn.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize  = 0;
                    btn.FlatAppearance.MouseOverBackColor =
                        System.Drawing.Color.FromArgb(60, 60, 90);
                    btn.Font        = new System.Drawing.Font("Segoe UI", 9.5F);
                    btn.ForeColor   = System.Drawing.Color.White;
                    btn.Location    = new System.Drawing.Point(0, top);
                    btn.Size        = new System.Drawing.Size(185, 42);
                    btn.Text        = texto;
                    btn.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.Padding     = new System.Windows.Forms.Padding(18, 0, 0, 0);
                    btn.Cursor      = System.Windows.Forms.Cursors.Hand;
                };

            configurarBtn(this.btnEjercicios,   "🏋  Ejercicios",        100);
            configurarBtn(this.btnConfigPausas, "⚙️  Config. Pausas",    145);
            configurarBtn(this.btnEmpleados,    "👥  Empleados",          190);
            configurarBtn(this.btnReportes,     "📊  Reportes",           235);

            this.btnEjercicios.Name   = "btnEjercicios";
            this.btnConfigPausas.Name = "btnConfigPausas";
            this.btnEmpleados.Name    = "btnEmpleados";
            this.btnReportes.Name     = "btnReportes";

            this.btnEjercicios.Click   += new System.EventHandler(this.btnEjercicios_Click);
            this.btnConfigPausas.Click += new System.EventHandler(this.btnConfigPausas_Click);
            this.btnEmpleados.Click    += new System.EventHandler(this.btnEmpleados_Click);
            this.btnReportes.Click     += new System.EventHandler(this.btnReportes_Click);

            // ── panelBottom (Cerrar sesión al fondo del sidebar) ────────────
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(35, 35, 55);
            this.panelBottom.Controls.Add(this.btnCerrarSesion);
            this.panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height    = 50;
            this.panelBottom.Name      = "panelBottom";

            // ── btnCerrarSesion ─────────────────────────────────────────────
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(35, 35, 55);
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnCerrarSesion.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(220, 150, 150);
            this.btnCerrarSesion.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrarSesion.Name      = "btnCerrarSesion";
            this.btnCerrarSesion.Text      = "🚪  Cerrar sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Padding   = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCerrarSesion.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Click    += new System.EventHandler(this.btnCerrarSesion_Click);

            // ── panelContenido ──────────────────────────────────────────────
            this.panelContenido.BackColor = System.Drawing.SystemColors.Control;
            this.panelContenido.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Name      = "panelContenido";
            this.panelContenido.Padding   = new System.Windows.Forms.Padding(10);

            // ── FrmAdminPrincipal ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize         = new System.Drawing.Size(850, 520);
            this.Name                = "FrmAdminPrincipal";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "PausasActivasApp — Panel Administrador";
            this.Load               += new System.EventHandler(this.FrmAdminPrincipal_Load);
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdminPrincipal_FormClosing);

            this.panelBottom.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel   panelSidebar;
        private System.Windows.Forms.Label   lblAppTitle;
        private System.Windows.Forms.Label   lblUsuarioSesion;
        private System.Windows.Forms.Label   separador1;
        private System.Windows.Forms.Button  btnEjercicios;
        private System.Windows.Forms.Button  btnConfigPausas;
        private System.Windows.Forms.Button  btnEmpleados;
        private System.Windows.Forms.Button  btnReportes;
        private System.Windows.Forms.Panel   panelBottom;
        private System.Windows.Forms.Button  btnCerrarSesion;
        private System.Windows.Forms.Panel   panelContenido;
    }
}
