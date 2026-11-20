namespace PausasActivasApp.Formularios
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.panelFondo       = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.lblSubtitulo     = new System.Windows.Forms.Label();
            this.lblUsuario       = new System.Windows.Forms.Label();
            this.txtUsuario       = new System.Windows.Forms.TextBox();
            this.lblPasswordLabel = new System.Windows.Forms.Label();
            this.txtPassword      = new System.Windows.Forms.TextBox();
            this.btnIngresar      = new System.Windows.Forms.Button();
            this.lblMensaje       = new System.Windows.Forms.Label();
            this.panelFondo.SuspendLayout();
            this.SuspendLayout();

            // ── panelFondo ──────────────────────────────────────────────────
            this.panelFondo.BackColor   = System.Drawing.SystemColors.Control;
            this.panelFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFondo.Controls.Add(this.lblTitulo);
            this.panelFondo.Controls.Add(this.lblSubtitulo);
            this.panelFondo.Controls.Add(this.lblUsuario);
            this.panelFondo.Controls.Add(this.txtUsuario);
            this.panelFondo.Controls.Add(this.lblPasswordLabel);
            this.panelFondo.Controls.Add(this.txtPassword);
            this.panelFondo.Controls.Add(this.btnIngresar);
            this.panelFondo.Controls.Add(this.lblMensaje);
            this.panelFondo.Location = new System.Drawing.Point(30, 20);
            this.panelFondo.Name     = "panelFondo";
            this.panelFondo.Size     = new System.Drawing.Size(340, 360);
            this.panelFondo.TabIndex = 0;

            // ── lblTitulo ───────────────────────────────────────────────────
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 102, 153);
            this.lblTitulo.Location  = new System.Drawing.Point(10, 25);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(318, 35);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Pausas Activas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtitulo ────────────────────────────────────────────────
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location  = new System.Drawing.Point(10, 62);
            this.lblSubtitulo.Name      = "lblSubtitulo";
            this.lblSubtitulo.Size      = new System.Drawing.Size(318, 20);
            this.lblSubtitulo.TabIndex  = 1;
            this.lblSubtitulo.Text      = "Inicia sesión para continuar";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblUsuario ──────────────────────────────────────────────────
            this.lblUsuario.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.Location  = new System.Drawing.Point(30, 110);
            this.lblUsuario.Name      = "lblUsuario";
            this.lblUsuario.Size      = new System.Drawing.Size(280, 20);
            this.lblUsuario.TabIndex  = 2;
            this.lblUsuario.Text      = "Usuario:";

            // ── txtUsuario ──────────────────────────────────────────────────
            this.txtUsuario.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location  = new System.Drawing.Point(30, 133);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name      = "txtUsuario";
            this.txtUsuario.Size      = new System.Drawing.Size(280, 25);
            this.txtUsuario.TabIndex  = 3;
            this.txtUsuario.KeyDown  += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);

            // ── lblPasswordLabel ────────────────────────────────────────────
            this.lblPasswordLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPasswordLabel.Location  = new System.Drawing.Point(30, 175);
            this.lblPasswordLabel.Name      = "lblPasswordLabel";
            this.lblPasswordLabel.Size      = new System.Drawing.Size(280, 20);
            this.lblPasswordLabel.TabIndex  = 4;
            this.lblPasswordLabel.Text      = "Contraseña:";

            // ── txtPassword ─────────────────────────────────────────────────
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location     = new System.Drawing.Point(30, 198);
            this.txtPassword.MaxLength    = 100;
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size         = new System.Drawing.Size(280, 25);
            this.txtPassword.TabIndex     = 5;
            this.txtPassword.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // ── btnIngresar ─────────────────────────────────────────────────
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(0, 102, 153);
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location  = new System.Drawing.Point(30, 250);
            this.btnIngresar.Name      = "btnIngresar";
            this.btnIngresar.Size      = new System.Drawing.Size(280, 38);
            this.btnIngresar.TabIndex  = 6;
            this.btnIngresar.Text      = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click    += new System.EventHandler(this.btnIngresar_Click);

            // ── lblMensaje ──────────────────────────────────────────────────
            this.lblMensaje.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensaje.Location  = new System.Drawing.Point(30, 300);
            this.lblMensaje.Name      = "lblMensaje";
            this.lblMensaje.Size      = new System.Drawing.Size(280, 40);
            this.lblMensaje.TabIndex  = 7;
            this.lblMensaje.Text      = string.Empty;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── FrmLogin (formulario) ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.panelFondo);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.MinimizeBox         = true;
            this.Name                = "FrmLogin";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "PausasActivasApp — Iniciar Sesión";
            this.Load               += new System.EventHandler(this.FrmLogin_Load);
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);

            this.panelFondo.ResumeLayout(false);
            this.panelFondo.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Controles del formulario ────────────────────────────────────────
        private System.Windows.Forms.Panel    panelFondo;
        private System.Windows.Forms.Label    lblTitulo;
        private System.Windows.Forms.Label    lblSubtitulo;
        private System.Windows.Forms.Label    lblUsuario;
        private System.Windows.Forms.TextBox  txtUsuario;
        private System.Windows.Forms.Label    lblPasswordLabel;
        private System.Windows.Forms.TextBox  txtPassword;
        private System.Windows.Forms.Button   btnIngresar;
        private System.Windows.Forms.Label    lblMensaje;
    }
}
