using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PausasActivasApp.Datos;
using PausasActivasApp.Modelos;

namespace PausasActivasApp.Formularios.Admin
{
    /// <summary>
    /// Diálogo modal para crear o editar un ejercicio.
    /// Si <paramref name="ejercicioEditar"/> es null → modo Nuevo.
    /// Si tiene valor → modo Editar.
    /// </summary>
    public partial class FrmEjercicioDetalle : Form
    {
        private readonly Ejercicio? _ejercicioOriginal;
        private string? _rutaImagenSeleccionada;   // ruta absoluta elegida por el usuario

        public FrmEjercicioDetalle(Ejercicio? ejercicioEditar)
        {
            InitializeComponent();
            _ejercicioOriginal = ejercicioEditar;
        }

        // ════════════════════════════════════════════════════════════════════
        // CARGA
        // ════════════════════════════════════════════════════════════════════

        private void FrmEjercicioDetalle_Load(object sender, EventArgs e)
        {
            if (_ejercicioOriginal == null)
            {
                // Modo Nuevo
                this.Text           = "Nuevo Ejercicio";
                lblTitulo.Text      = "Nuevo Ejercicio";
                chkActivo.Checked   = true;
            }
            else
            {
                // Modo Editar
                this.Text              = "Editar Ejercicio";
                lblTitulo.Text         = "Editar Ejercicio";
                txtTitulo.Text         = _ejercicioOriginal.Titulo;
                txtDescripcion.Text    = _ejercicioOriginal.Descripcion;
                nudDuracion.Value      = _ejercicioOriginal.DuracionSegundos;
                chkActivo.Checked      = _ejercicioOriginal.Activo;
                _rutaImagenSeleccionada = _ejercicioOriginal.ImagenRuta;
                lblRutaActual.Text     = _ejercicioOriginal.ImagenRuta ?? "(sin imagen)";
                CargarPreview(_ejercicioOriginal.ImagenRuta);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // EVENTOS
        // ════════════════════════════════════════════════════════════════════

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title  = "Seleccionar imagen del ejercicio",
                Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos|*.*",
                CheckFileExists = true
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            string rutaAbsoluta = dlg.FileName;

            // Copiar imagen a la carpeta Recursos/Imagenes del proyecto en ejecución
            string carpetaDestino = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Recursos", "Imagenes");
            Directory.CreateDirectory(carpetaDestino);

            string nombreArchivo  = Path.GetFileName(rutaAbsoluta);
            string rutaDestino    = Path.Combine(carpetaDestino, nombreArchivo);

            // Si ya existe con el mismo nombre, se sobreescribe
            File.Copy(rutaAbsoluta, rutaDestino, overwrite: true);

            // Guardamos la ruta relativa (lo que va a la BD)
            _rutaImagenSeleccionada = Path.Combine("Recursos", "Imagenes", nombreArchivo);
            lblRutaActual.Text      = _rutaImagenSeleccionada;

            CargarPreview(rutaDestino);  // preview desde ruta absoluta
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            _rutaImagenSeleccionada = null;
            lblRutaActual.Text      = "(sin imagen)";
            picPreview.Image        = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var ej = new Ejercicio
                {
                    Titulo           = txtTitulo.Text.Trim(),
                    Descripcion      = txtDescripcion.Text.Trim(),
                    DuracionSegundos = (int)nudDuracion.Value,
                    ImagenRuta       = _rutaImagenSeleccionada,
                    Activo           = chkActivo.Checked
                };

                if (_ejercicioOriginal == null)
                {
                    EjercicioDAL.Insertar(ej);
                }
                else
                {
                    ej.IdEjercicio = _ejercicioOriginal.IdEjercicio;
                    EjercicioDAL.Actualizar(ej);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción / instrucciones son obligatorias.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (nudDuracion.Value < 1)
            {
                MessageBox.Show("La duración debe ser al menos 1 segundo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDuracion.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Carga la imagen en el PictureBox de previsualización.
        /// Soporta GIFs animados nativamente (Image.FromFile).
        /// </summary>
        private void CargarPreview(string? ruta)
        {
            picPreview.Image = null;

            if (string.IsNullOrEmpty(ruta)) return;

            // Si es ruta relativa, convertir a absoluta
            if (!Path.IsPathRooted(ruta))
                ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

            if (!File.Exists(ruta)) return;

            try
            {
                // Cargar en memoria para no bloquear el archivo en disco
                byte[] bytes = File.ReadAllBytes(ruta);
                using var ms = new System.IO.MemoryStream(bytes);
                picPreview.Image = Image.FromStream(ms);
            }
            catch
            {
                picPreview.Image = null;
            }
        }
    }
}
