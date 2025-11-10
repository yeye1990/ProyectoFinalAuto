using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginComponents;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginWaits;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginActions;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Screenshot;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin
{
    public class ECommerceLoginPage
    {
        private readonly IWebDriver _driver;
        private readonly LoginComponentsPage _loginComponents;
        private readonly LoginWaitsPage _loginWaits;
        private readonly LoginActionsPage _loginActions;
        private string? _carpetaEvidenciaActual;

        /// <summary>
        /// Constructor de la clase ECommerceLoginPage.
        /// Inicializa los componentes, esperas y acciones del login.
        /// </summary>
        public ECommerceLoginPage(IWebDriver driver)
        {
            _driver = driver;
            _loginComponents = new LoginComponentsPage(driver);
            _loginWaits = new LoginWaitsPage(driver);
            _loginActions = new LoginActionsPage(driver);
        }

        /// <summary>
        /// Verifica que el formulario de inicio de sesión se haya cargado correctamente.
        /// </summary>
        public void Assert_TituloConfirmacionCargarPaginaWeb(string assert_title_form_login) {
            _loginWaits.UsarElementExists(_loginComponents.GetByTitleFormLogin());
            Assert.That(_loginComponents.GetWebElementTitleFormLogin().Text, Is.EqualTo(assert_title_form_login));
        }

        /// <summary>
        /// Ingresa las credenciales del usuario (usuario y contraseña) en el formulario de inicio de sesión.
        /// </summary>
        public void IngresarCredenciales(string usuario, string contrasenna) {
            _loginComponents.GetWebElementInptNombreUsuario().SendKeys(usuario);
            _loginComponents.GetWebElementInptContrasennaUsuario().SendKeys(contrasenna);
        }

        /// <summary>
        /// Hace clic en el botón de inicio de sesión del formulario.
        /// </summary>
        public void HacerClicBoton() {
            _loginComponents.GetWebElementBtn_IngresarFormLogin().Click();
        }

        /// <summary>
        /// Verifica que el usuario haya ingresado correctamente al sistema validando el título de la página de productos.
        /// </summary>
        public string Assert_TituloConfirmacionIngreso() {
            _loginWaits.UsarElementIsVisible(_loginComponents.GetByTitleProductos());
            return _loginComponents.GetWebElementTitleProducto().Text;
        }

        /// <summary>
        /// Verifica que la página actual cargada en el navegador corresponde
        /// al sitio principal de la aplicación, comprobando que la URL
        /// contenga el dominio "saucedemo.com".
        /// </summary>
        public void Assert_PaginaPrincipal() { 
            Assert.That(_driver.Url, Does.Contain("saucedemo.com"));
        }

        /// <summary>
        /// Espera a que el mensaje de error de inicio de sesión esté presente en la página
        /// y devuelve el texto mostrado en dicho mensaje.
        /// </summary>
        public string Assert_MensajeErrorLogin()
        {
            _loginWaits.UsarElementExists(_loginComponents.GetByMensajeErrorLogin());
            return _loginComponents.GetWebElementMensajeErrorLogin().Text;
        }

        /// <summary>
        /// Captura una evidencia (screenshot) del estado actual de la página y la guarda en una carpeta dinámica.
        /// </summary>
        public void EjecutarCapturaEvidencia(IWebDriver driver)
        {
            //Espera implicita antes de la captura
            _loginWaits.EsperaCapturaPantalla();

            //Ruta base hasta LoginValido
            string baseFolder = Path.GetFullPath(
                Path.Combine(TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceLogin", "Screenshot", "LoginValido")
            );

            //Crear carpeta solo una vez por ejecución del test
            if (string.IsNullOrEmpty(_carpetaEvidenciaActual))
            {
                // Carpeta dinámica basada en fecha/hora
                string folderName = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                _carpetaEvidenciaActual = Path.GetFullPath(
                    Path.Combine(baseFolder, folderName)
                );

                if (!Directory.Exists(_carpetaEvidenciaActual))
                    Directory.CreateDirectory(_carpetaEvidenciaActual);
            }

            //Nombre único del archivo
            string nombreArchivo = $"Captura_Evidencia_LoginValido_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            //Ruta completa final
            string fullPath = Path.GetFullPath(
                Path.Combine(_carpetaEvidenciaActual, nombreArchivo)
            );

            //Toma la captura
            ScreenshotBase.TakeScreenshot(driver, fullPath);
        }

        /// <summary>
        /// Captura una evidencia (screenshot) del estado actual de la página y la guarda en una carpeta dinámica.
        /// </summary>
        public void EjecutarCapturaEvidenciaLoginInvalido(IWebDriver driver)
        {
            //Espera implicita antes de la captura
            _loginWaits.EsperaCapturaPantalla();

            //Ruta base hasta LoginValido
            string baseFolder = Path.GetFullPath(
                Path.Combine(TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceLogin", "Screenshot", "LoginInvalido")
            );

            //Crear carpeta solo una vez por ejecución del test
            if (string.IsNullOrEmpty(_carpetaEvidenciaActual))
            {
                // Carpeta dinámica basada en fecha/hora
                string folderName = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                _carpetaEvidenciaActual = Path.GetFullPath(
                    Path.Combine(baseFolder, folderName)
                );

                if (!Directory.Exists(_carpetaEvidenciaActual))
                    Directory.CreateDirectory(_carpetaEvidenciaActual);
            }

            //Nombre único del archivo
            string nombreArchivo = $"Captura_Evidencia_LoginValido_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            //Ruta completa final
            string fullPath = Path.GetFullPath(
                Path.Combine(_carpetaEvidenciaActual, nombreArchivo)
            );

            //Toma la captura
            ScreenshotBase.TakeScreenshot(driver, fullPath);
        }

    }
}
