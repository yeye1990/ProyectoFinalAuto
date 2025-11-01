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
        private static string _carpetaEvidenciaActual;

        public ECommerceLoginPage(IWebDriver driver)
        {
            _driver = driver;
            _loginComponents = new LoginComponentsPage(driver);
            _loginWaits = new LoginWaitsPage(driver);
            _loginActions = new LoginActionsPage(driver);
        }

        //Metodo que ejecuta las acciones para el ingreso al sistema
        public void Assert_TituloConfirmacionCargarPaginaWeb(string assert_title_form_login) {
            _loginWaits.UsarElementExists(_loginComponents.GetByTitleFormLogin());
            Assert.That(_loginComponents.GetWebElementTitleFormLogin().Text, Is.EqualTo(assert_title_form_login));
        }

        public void IngresarCredenciales(string usuario, string contrasenna) {
            _loginComponents.GetWebElementInptNombreUsuario().SendKeys(usuario);
            _loginComponents.GetWebElementInptContrasennaUsuario().SendKeys(contrasenna);
        }

        public void HacerClicBoton() {
            _loginComponents.GetWebElementBtn_IngresarFormLogin().Click();
        }

        public string Assert_TituloConfirmacionIngreso() {
            _loginWaits.UsarElementIsVisible(_loginComponents.GetByTitleProductos());
            return _loginComponents.GetWebElementTitleProducto().Text;
        }

        //Metodo para capturar la evidencia de las pruebas
        public void EjecutarCapturaEvidencia(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(1000);

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

    }
}
