using System;
using System.Windows.Forms;
using PausasActivasApp.Datos;

namespace PausasActivasApp
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// Establece el formulario de Login como ventana principal
    /// y configura el modo de cierre de la aplicación.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuraciones estándar de WinForms para .NET 8
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // La app NO termina cuando el último formulario se cierra;
            // se mantiene viva mientras haya un NotifyIcon activo (módulo empleado).
            // El cierre real lo controla ApplicationContext o Application.Exit().
            Application.Run(new Formularios.FrmLogin());
        }
    }
}
