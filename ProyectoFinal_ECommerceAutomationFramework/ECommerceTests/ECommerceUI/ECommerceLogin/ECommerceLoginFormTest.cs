using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.JsonReader;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin
{
    public class ECommerceLoginFormTest : DriverBase
    {
        /// <summary>
        /// Caso de prueba que valida el inicio de sesión exitoso en el sistema.
        /// Usa los datos provenientes de un archivo JSON a través de la clase DataLoginValido.
        /// </summary>
        /// <param name="nombre">Nombre de usuario válido.</param>
        /// <param name="contrasenna">Contraseña asociada al usuario.</param>
        /// <param name="assert_pass">Texto esperado que confirma el ingreso exitoso (por ejemplo, el título de la página de productos).</param>
        /// <param name="assert_title_form_login">Título esperado del formulario de inicio de sesión.</param>
        [TestCaseSource(typeof(DataLoginValido), nameof(DataLoginValido.GetJsonDataLoginValido))]
        public void Test_LoginValido(string nombre, string contrasenna, string assert_pass, string assert_title_form_login) {
            //Arrange
            var loginPage = new ECommerceLoginPage(Driver);

            //Act
            loginPage.Assert_TituloConfirmacionCargarPaginaWeb(assert_title_form_login);
            loginPage.IngresarCredenciales(nombre,contrasenna);
            loginPage.EjecutarCapturaEvidencia(Driver);
            loginPage.HacerClicBoton();
            loginPage.EjecutarCapturaEvidencia(Driver);
            
            //Assert
            Assert.That(loginPage.Assert_TituloConfirmacionIngreso(), Is.EqualTo(assert_pass));
        }
    }
}
