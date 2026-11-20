namespace PausasActivasApp.Formularios.Admin
{
    partial class FrmEjercicioDetalle
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
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.separadorH        = new System.Windows.Forms.Label();
            // ── Columna izquierda: campos ──
            this.panelIzquierdo    = new System.Windows.Forms.Panel();
            this.lblCampoTitulo    = new System.Windows.Forms.Label();
            this.txtTitulo         = new System.Windows.Forms.TextBox();
            this.lblCampoDesc      = new System.Windows.Forms.Label();
            this.txtDescripcion    = new System.Windows.Forms.TextBox();
            this.lblCampoDuracion  = new System.Windows.Forms.Label();
            this.nudDuracion       = new System.Windows.Forms.NumericUpDown();
            this.lblSegundos       = new System.Windows.Forms.Label();
            this.chkActivo         = new System.Windows.Forms.CheckBox();
            // ── Columna derecha: imagen ──
            this.panelDerecho      = new System.Windows.Forms.Panel();
            this.lblImagenTitulo   = new System.Windows.Forms.Label();
            this.picPreview        = new System.Windows.Forms.PictureBox();
            this.lblRutaActual     = new System.Windows.Forms.Label();
            this.btnExaminar       = new System.Windows.Forms.Button();
            this.btnQuitarImagen   = new System.Windows.Forms.Button();
            // ── Botones inferiores ──
            this.panelBotones      = new System.Windows.Forms.Panel();
            this.btnGuardar        = new System.Windows.Forms.Button();
            this.btnCancelar       = new System.Windows.Forms.Button();

            this.panelIzquierdo.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            // ── lblTitulo (encabezado del formulario) ───────────────────────
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 86, 130);
            this.lblTitulo.Location  = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(360, 30);
            this.lblTitulo.Text      = "Nuevo Ejercicio";

            // ── separadorH ──────────────────────────────────────────────────
            this.separadorH.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.separadorH.Location  = new System.Drawing.Point(12, 48);
            this.separadorH.Name      = "separadorH";
            this.separadorH.Size      = new System.Drawing.Size(696, 1);

            // ════════════════════════════════════════════════════════════════
            // PANEL IZQUIERDO — Campos del ejercicio
            // ════════════════════════════════════════════════════════════════
            this.panelIzquierdo.Controls.Add(this.lblCampoTitulo);
            this.panelIzquierdo.Controls.Add(this.txtTitulo);
            this.panelIzquierdo.Controls.Add(this.lblCampoDesc);
            this.panelIzquierdo.Controls.Add(this.txtDescripcion);
            this.panelIzquierdo.Controls.Add(this.lblCampoDuracion);
            this.panelIzquierdo.Controls.Add(this.nudDuracion);
            this.panelIzquierdo.Controls.Add(this.lblSegundos);
            this.panelIzquierdo.Controls.Add(this.chkActivo);
            this.panelIzquierdo.Location = new System.Drawing.Point(12, 58);
            this.panelIzquierdo.Name     = "panelIzquierdo";
            this.panelIzquierdo.Size     = new System.Drawing.Size(360, 420);

            // lblCampoTitulo
            this.lblCampoTitulo.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCampoTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCampoTitulo.Size     = new System.Drawing.Size(340, 20);
            this.lblCampoTitulo.Text     = "Título del ejercicio *";
            this.lblCampoTitulo.Name     = "lblCampoTitulo";

            // txtTitulo
            this.txtTitulo.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitulo.Location  = new System.Drawing.Point(0, 22);
            this.txtTitulo.MaxLength = 150;
            this.txtTitulo.Name      = "txtTitulo";
            this.txtTitulo.Size      = new System.Drawing.Size(340, 25);

            // lblCampoDesc
            this.lblCampoDesc.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCampoDesc.Location = new System.Drawing.Point(0, 62);
            this.lblCampoDesc.Size     = new System.Drawing.Size(340, 20);
            this.lblCampoDesc.Text     = "Descripción / Instrucciones *";
            this.lblCampoDesc.Name     = "lblCampoDesc";

            // txtDescripcion
            this.txtDescripcion.Font       = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescripcion.Location   = new System.Drawing.Point(0, 84);
            this.txtDescripcion.Multiline  = true;
            this.txtDescripcion.Name       = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size       = new System.Drawing.Size(340, 240);

            // lblCampoDuracion
            this.lblCampoDuracion.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCampoDuracion.Location = new System.Drawing.Point(0, 338);
            this.lblCampoDuracion.Size     = new System.Drawing.Size(200, 20);
            this.lblCampoDuracion.Text     = "Duración *";
            this.lblCampoDuracion.Name     = "lblCampoDuracion";

            // nudDuracion
            this.nudDuracion.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDuracion.Location  = new System.Drawing.Point(0, 360);
            this.nudDuracion.Maximum   = 3600;
            this.nudDuracion.Minimum   = 1;
            this.nudDuracion.Name      = "nudDuracion";
            this.nudDuracion.Size      = new System.Drawing.Size(90, 25);
            this.nudDuracion.Value     = 30;

            // lblSegundos
            this.lblSegundos.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSegundos.ForeColor = System.Drawing.Color.Gray;
            this.lblSegundos.Location  = new System.Drawing.Point(96, 363);
            this.lblSegundos.Name      = "lblSegundos";
            this.lblSegundos.Size      = new System.Drawing.Size(80, 20);
            this.lblSegundos.Text      = "segundos";

            // chkActivo
            this.chkActivo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActivo.Location  = new System.Drawing.Point(0, 395);
            this.chkActivo.Name      = "chkActivo";
            this.chkActivo.Size      = new System.Drawing.Size(200, 22);
            this.chkActivo.Text      = "Ejercicio activo";

            // ════════════════════════════════════════════════════════════════
            // PANEL DERECHO — Imagen y previsualización
            // ════════════════════════════════════════════════════════════════
            this.panelDerecho.Controls.Add(this.lblImagenTitulo);
            this.panelDerecho.Controls.Add(this.picPreview);
            this.panelDerecho.Controls.Add(this.lblRutaActual);
            this.panelDerecho.Controls.Add(this.btnExaminar);
            this.panelDerecho.Controls.Add(this.btnQuitarImagen);
            this.panelDerecho.Location = new System.Drawing.Point(385, 58);
            this.panelDerecho.Name     = "panelDerecho";
            this.panelDerecho.Size     = new System.Drawing.Size(323, 420);

            // lblImagenTitulo
            this.lblImagenTitulo.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImagenTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblImagenTitulo.Name     = "lblImagenTitulo";
            this.lblImagenTitulo.Size     = new System.Drawing.Size(320, 20);
            this.lblImagenTitulo.Text     = "Imagen / GIF demostrativo";

            // picPreview
            this.picPreview.BackColor   = System.Drawing.Color.FromArgb(230, 230, 230);
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location    = new System.Drawing.Point(0, 24);
            this.picPreview.Name        = "picPreview";
            this.picPreview.Size        = new System.Drawing.Size(320, 280);
            this.picPreview.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblRutaActual
            this.lblRutaActual.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRutaActual.ForeColor = System.Drawing.Color.DimGray;
            this.lblRutaActual.Location  = new System.Drawing.Point(0, 310);
            this.lblRutaActual.Name      = "lblRutaActual";
            this.lblRutaActual.Size      = new System.Drawing.Size(320, 36);
            this.lblRutaActual.Text      = "(sin imagen)";

            // btnExaminar
            this.btnExaminar.BackColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.Location  = new System.Drawing.Point(0, 356);
            this.btnExaminar.Name      = "btnExaminar";
            this.btnExaminar.Size      = new System.Drawing.Size(154, 32);
            this.btnExaminar.Text      = "📂 Examinar...";
            this.btnExaminar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.Click    += new System.EventHandler(this.btnExaminar_Click);

            // btnQuitarImagen
            this.btnQuitarImagen.BackColor = System.Drawing.Color.FromArgb(130, 50, 50);
            this.btnQuitarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarImagen.FlatAppearance.BorderSize = 0;
            this.btnQuitarImagen.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarImagen.ForeColor = System.Drawing.Color.White;
            this.btnQuitarImagen.Location  = new System.Drawing.Point(162, 356);
            this.btnQuitarImagen.Name      = "btnQuitarImagen";
            this.btnQuitarImagen.Size      = new System.Drawing.Size(158, 32);
            this.btnQuitarImagen.Text      = "🗑 Quitar imagen";
            this.btnQuitarImagen.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarImagen.Click    += new System.EventHandler(this.btnQuitarImagen_Click);

            // ════════════════════════════════════════════════════════════════
            // PANEL BOTONES
            // ════════════════════════════════════════════════════════════════
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Height    = 55;
            this.panelBotones.Name      = "panelBotones";
            this.panelBotones.Padding   = new System.Windows.Forms.Padding(10, 10, 10, 10);

            // btnGuardar
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 140, 70);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location  = new System.Drawing.Point(448, 10);
            this.btnGuardar.Name      = "btnGuardar";
            this.btnGuardar.Size      = new System.Drawing.Size(120, 35);
            this.btnGuardar.Text      = "💾 Guardar";
            this.btnGuardar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click    += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location  = new System.Drawing.Point(576, 10);
            this.btnCancelar.Name      = "btnCancelar";
            this.btnCancelar.Size      = new System.Drawing.Size(120, 35);
            this.btnCancelar.Text      = "Cancelar";
            this.btnCancelar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click    += new System.EventHandler(this.btnCancelar_Click);

            // ── FrmEjercicioDetalle ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(720, 560);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.separadorH);
            this.Controls.Add(this.panelIzquierdo);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelBotones);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FrmEjercicioDetalle";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Ejercicio";
            this.Load               += new System.EventHandler(this.FrmEjercicioDetalle_Load);

            this.panelIzquierdo.ResumeLayout(false);
            this.panelIzquierdo.PerformLayout();
            this.panelDerecho.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label           lblTitulo;
        private System.Windows.Forms.Label           separadorH;
        private System.Windows.Forms.Panel           panelIzquierdo;
        private System.Windows.Forms.Label           lblCampoTitulo;
        private System.Windows.Forms.TextBox         txtTitulo;
        private System.Windows.Forms.Label           lblCampoDesc;
        private System.Windows.Forms.TextBox         txtDescripcion;
        private System.Windows.Forms.Label           lblCampoDuracion;
        private System.Windows.Forms.NumericUpDown   nudDuracion;
        private System.Windows.Forms.Label           lblSegundos;
        private System.Windows.Forms.CheckBox        chkActivo;
        private System.Windows.Forms.Panel           panelDerecho;
        private System.Windows.Forms.Label           lblImagenTitulo;
        private System.Windows.Forms.PictureBox      picPreview;
        private System.Windows.Forms.Label           lblRutaActual;
        private System.Windows.Forms.Button          btnExaminar;
        private System.Windows.Forms.Button          btnQuitarImagen;
        private System.Windows.Forms.Panel           panelBotones;
        private System.Windows.Forms.Button          btnGuardar;
        private System.Windows.Forms.Button          btnCancelar;
    }
}
