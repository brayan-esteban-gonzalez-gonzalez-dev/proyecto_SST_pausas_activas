namespace PausasActivasApp.Formularios.Admin
{
    partial class FrmRestablecerPassword
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
            this.lblTitulo           = new System.Windows.Forms.Label();
            this.separadorH          = new System.Windows.Forms.Label();
            this.lblUsuarioInfo      = new System.Windows.Forms.Label();
            this.lblPassword         = new System.Windows.Forms.Label();
            this.txtPassword        = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirm  = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.panelBotones        = new System.Windows.Forms.Panel();
            this.btnGuardar          = new System.Windows.Forms.Button();
            this.btnCancelar         = new System.Windows.Forms.Button();

            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ── lblTitulo ───────────────────────────────────────────────────
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(110, 70, 160);
            this.lblTitulo.Location  = new System.Drawing.Point(16, 14);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(340, 24);
            this.lblTitulo.Text      = "🔑 Restablecer Contraseña";

            // ── separadorH ──────────────────────────────────────────────────
            this.separadorH.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.separadorH.Location  = new System.Drawing.Point(16, 42);
            this.separadorH.Name      = "separadorH";
            this.separadorH.Size      = new System.Drawing.Size(350, 1);

            // ── lblUsuarioInfo ──────────────────────────────────────────────
            this.lblUsuarioInfo.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioInfo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblUsuarioInfo.Location  = new System.Drawing.Point(16, 52);
            this.lblUsuarioInfo.Name      = "lblUsuarioInfo";
            this.lblUsuarioInfo.Size      = new System.Drawing.Size(350, 20);
            this.lblUsuarioInfo.Text      = "Usuario: ...";

            // ── lblPassword / txtPassword ───────────────────────────────────
            this.lblPassword.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(16, 82);
            this.lblPassword.Name     = "lblPassword";
            this.lblPassword.Size     = new System.Drawing.Size(350, 18);
            this.lblPassword.Text     = "Nueva contraseña *";

            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location     = new System.Drawing.Point(16, 102);
            this.txtPassword.MaxLength    = 100;
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size         = new System.Drawing.Size(350, 25);

            // ── lblPasswordConfirm / txtPasswordConfirm ─────────────────────
            this.lblPasswordConfirm.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordConfirm.Location = new System.Drawing.Point(16, 138);
            this.lblPasswordConfirm.Name     = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size     = new System.Drawing.Size(350, 18);
            this.lblPasswordConfirm.Text     = "Confirmar nueva contraseña *";

            this.txtPasswordConfirm.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasswordConfirm.Location     = new System.Drawing.Point(16, 158);
            this.txtPasswordConfirm.MaxLength    = 100;
            this.txtPasswordConfirm.Name         = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '●';
            this.txtPasswordConfirm.Size         = new System.Drawing.Size(350, 25);

            // ── panelBotones ────────────────────────────────────────────────
            this.panelBotones.BackColor = System.Drawing.SystemColors.Control;
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Height    = 52;
            this.panelBotones.Location  = new System.Drawing.Point(0, 206);
            this.panelBotones.Name      = "panelBotones";

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(110, 70, 160);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location  = new System.Drawing.Point(145, 10);
            this.btnGuardar.Name      = "btnGuardar";
            this.btnGuardar.Size      = new System.Drawing.Size(120, 32);
            this.btnGuardar.Text      = "💾 Guardar";
            this.btnGuardar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click    += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location  = new System.Drawing.Point(272, 10);
            this.btnCancelar.Name      = "btnCancelar";
            this.btnCancelar.Size      = new System.Drawing.Size(95, 32);
            this.btnCancelar.Text      = "Cancelar";
            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click    += new System.EventHandler(this.btnCancelar_Click);

            // ── FrmRestablecerPassword ──────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(382, 258);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.separadorH);
            this.Controls.Add(this.lblUsuarioInfo);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.panelBotones);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FrmRestablecerPassword";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Restablecer Contraseña";
            this.Load               += new System.EventHandler(this.FrmRestablecerPassword_Load);

            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   separadorH;
        private System.Windows.Forms.Label   lblUsuarioInfo;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label   lblPasswordConfirm;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Panel   panelBotones;
        private System.Windows.Forms.Button  btnGuardar;
        private System.Windows.Forms.Button  btnCancelar;
    }
}
