namespace PausasActivasApp.Formularios.Admin
{
    partial class FrmUsuarioDetalle
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
            this.lblNombre           = new System.Windows.Forms.Label();
            this.txtNombre           = new System.Windows.Forms.TextBox();
            this.lblUsuario          = new System.Windows.Forms.Label();
            this.txtUsuario          = new System.Windows.Forms.TextBox();
            this.lblRol              = new System.Windows.Forms.Label();
            this.cmbRol              = new System.Windows.Forms.ComboBox();
            this.chkActivo           = new System.Windows.Forms.CheckBox();
            this.lblAvisoEdicion     = new System.Windows.Forms.Label();
            this.panelPasswords      = new System.Windows.Forms.Panel();
            this.lblPassword         = new System.Windows.Forms.Label();
            this.txtPassword        = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirm  = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.panelBotones        = new System.Windows.Forms.Panel();
            this.btnGuardar          = new System.Windows.Forms.Button();
            this.btnCancelar         = new System.Windows.Forms.Button();

            this.panelPasswords.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ── lblTitulo ───────────────────────────────────────────────────
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTitulo.Location  = new System.Drawing.Point(16, 14);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(360, 28);
            this.lblTitulo.Text      = "Usuario";

            // ── separadorH ──────────────────────────────────────────────────
            this.separadorH.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.separadorH.Location  = new System.Drawing.Point(16, 46);
            this.separadorH.Name      = "separadorH";
            this.separadorH.Size      = new System.Drawing.Size(380, 1);

            // ── lblNombre / txtNombre ───────────────────────────────────────
            this.lblNombre.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(16, 60);
            this.lblNombre.Name     = "lblNombre";
            this.lblNombre.Size     = new System.Drawing.Size(360, 18);
            this.lblNombre.Text     = "Nombre completo *";

            this.txtNombre.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location  = new System.Drawing.Point(16, 82);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name      = "txtNombre";
            this.txtNombre.Size      = new System.Drawing.Size(376, 25);

            // ── lblUsuario / txtUsuario ─────────────────────────────────────
            this.lblUsuario.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(16, 120);
            this.lblUsuario.Name     = "lblUsuario";
            this.lblUsuario.Size     = new System.Drawing.Size(360, 18);
            this.lblUsuario.Text     = "Nombre de usuario (Login) *";

            this.txtUsuario.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location  = new System.Drawing.Point(16, 142);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name      = "txtUsuario";
            this.txtUsuario.Size      = new System.Drawing.Size(376, 25);

            // ── lblRol / cmbRol ─────────────────────────────────────────────
            this.lblRol.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRol.Location = new System.Drawing.Point(16, 180);
            this.lblRol.Name     = "lblRol";
            this.lblRol.Size     = new System.Drawing.Size(180, 18);
            this.lblRol.Text     = "Rol de usuario *";

            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRol.Location      = new System.Drawing.Point(16, 202);
            this.cmbRol.Name          = "cmbRol";
            this.cmbRol.Size          = new System.Drawing.Size(180, 25);

            // ── chkActivo ───────────────────────────────────────────────────
            this.chkActivo.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.Location = new System.Drawing.Point(220, 204);
            this.chkActivo.Name     = "chkActivo";
            this.chkActivo.Size     = new System.Drawing.Size(170, 22);
            this.chkActivo.Text     = "Cuenta activa";

            // ── lblAvisoEdicion ─────────────────────────────────────────────
            this.lblAvisoEdicion.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblAvisoEdicion.ForeColor = System.Drawing.Color.DimGray;
            this.lblAvisoEdicion.Location  = new System.Drawing.Point(16, 245);
            this.lblAvisoEdicion.Name      = "lblAvisoEdicion";
            this.lblAvisoEdicion.Size      = new System.Drawing.Size(376, 35);
            this.lblAvisoEdicion.Text      = "ℹ Para cambiar la contraseña de este usuario, utiliza el botón 'Restablecer Contraseña' en la barra principal.";
            this.lblAvisoEdicion.Visible   = false;

            // ── panelPasswords ──────────────────────────────────────────────
            this.panelPasswords.Controls.Add(this.lblPassword);
            this.panelPasswords.Controls.Add(this.txtPassword);
            this.panelPasswords.Controls.Add(this.lblPasswordConfirm);
            this.panelPasswords.Controls.Add(this.txtPasswordConfirm);
            this.panelPasswords.Location = new System.Drawing.Point(12, 238);
            this.panelPasswords.Name     = "panelPasswords";
            this.panelPasswords.Size     = new System.Drawing.Size(384, 126);

            // lblPassword
            this.lblPassword.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(4, 5);
            this.lblPassword.Name     = "lblPassword";
            this.lblPassword.Size     = new System.Drawing.Size(360, 18);
            this.lblPassword.Text     = "Contraseña inicial *";

            // txtPassword
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location     = new System.Drawing.Point(4, 26);
            this.txtPassword.MaxLength    = 100;
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size         = new System.Drawing.Size(376, 25);

            // lblPasswordConfirm
            this.lblPasswordConfirm.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordConfirm.Location = new System.Drawing.Point(4, 62);
            this.lblPasswordConfirm.Name     = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size     = new System.Drawing.Size(360, 18);
            this.lblPasswordConfirm.Text     = "Confirmar contraseña *";

            // txtPasswordConfirm
            this.txtPasswordConfirm.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasswordConfirm.Location     = new System.Drawing.Point(4, 83);
            this.txtPasswordConfirm.MaxLength    = 100;
            this.txtPasswordConfirm.Name         = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '●';
            this.txtPasswordConfirm.Size         = new System.Drawing.Size(376, 25);

            // ── panelBotones ────────────────────────────────────────────────
            this.panelBotones.BackColor = System.Drawing.SystemColors.Control;
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Height    = 52;
            this.panelBotones.Location  = new System.Drawing.Point(0, 375);
            this.panelBotones.Name      = "panelBotones";

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 140, 70);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location  = new System.Drawing.Point(170, 10);
            this.btnGuardar.Name      = "btnGuardar";
            this.btnGuardar.Size      = new System.Drawing.Size(110, 32);
            this.btnGuardar.Text      = "💾 Guardar";
            this.btnGuardar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click    += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location  = new System.Drawing.Point(286, 10);
            this.btnCancelar.Name      = "btnCancelar";
            this.btnCancelar.Size      = new System.Drawing.Size(106, 32);
            this.btnCancelar.Text      = "Cancelar";
            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click    += new System.EventHandler(this.btnCancelar_Click);

            // ── FrmUsuarioDetalle ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(410, 427);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.separadorH);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.lblAvisoEdicion);
            this.Controls.Add(this.panelPasswords);
            this.Controls.Add(this.panelBotones);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FrmUsuarioDetalle";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Detalle de Usuario";
            this.Load               += new System.EventHandler(this.FrmUsuarioDetalle_Load);

            this.panelPasswords.ResumeLayout(false);
            this.panelPasswords.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label    lblTitulo;
        private System.Windows.Forms.Label    separadorH;
        private System.Windows.Forms.Label    lblNombre;
        private System.Windows.Forms.TextBox  txtNombre;
        private System.Windows.Forms.Label    lblUsuario;
        private System.Windows.Forms.TextBox  txtUsuario;
        private System.Windows.Forms.Label    lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label    lblAvisoEdicion;
        private System.Windows.Forms.Panel    panelPasswords;
        private System.Windows.Forms.Label    lblPassword;
        private System.Windows.Forms.TextBox  txtPassword;
        private System.Windows.Forms.Label    lblPasswordConfirm;
        private System.Windows.Forms.TextBox  txtPasswordConfirm;
        private System.Windows.Forms.Panel    panelBotones;
        private System.Windows.Forms.Button   btnGuardar;
        private System.Windows.Forms.Button   btnCancelar;
    }
}
