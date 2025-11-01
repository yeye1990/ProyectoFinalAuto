using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginComponents
{
    internal class LoginComponentsPage
    {
        private readonly IWebDriver _driver;

        // Definición de los localizadores By
        private readonly By _txtTitleFormLogin = By.CssSelector("div.login_logo");
        private readonly By _inptNombreUsuario = By.Id("user-name");
        private readonly By _inptContrasennaUsuario = By.Id("password");
        private readonly By _btnIngresarFormLogin = By.Id("login-button");
        private readonly By _txtTitleProductos = By.CssSelector("div span.title");

        /// <summary>
        //private readonly By _btnPruebas = By.XPath("(//button[contains(@class,'btn_inventory')]) [5]");
        /// </summary>

        //Definición de los IWebElementos
        private IWebElement Txt_Title_Form_Login => _driver.FindElement(_txtTitleFormLogin);
        private IWebElement Inpt_Nombre_Usuario => _driver.FindElement(_inptNombreUsuario);
        private IWebElement Inpt_Contrasenna_Usuario => _driver.FindElement(_inptContrasennaUsuario);
        private IWebElement Btn_Ingresar_Form_Login => _driver.FindElement(_btnIngresarFormLogin);
        private IWebElement Txt_Title_Producto => _driver.FindElement(_txtTitleProductos);


        /// <summary>
        //public IWebElement Btn_Pruebas => _driver.FindElement(_btnPruebas);
        /// </summary>
        /// <param name="driver"></param>

        public LoginComponentsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //Metodos para retornar el valor del elemento por By
        public By GetByTitleFormLogin() => _txtTitleFormLogin;
        public By GetByNombreUsuario() => _inptNombreUsuario;
        public By GetByContrasennaUsuario() => _inptContrasennaUsuario;
        public By GetByBtnIngresarFormLogin() => _btnIngresarFormLogin;
        public By GetByTitleProductos() => _txtTitleProductos;

        /// <summary>
        //public By GetByBtnPruebas() => _btnPruebas;
        /// </summary>
        /// <returns></returns>

        //Metodos para retornar el valor del elemento por Web Elemento
        public IWebElement GetWebElementTitleFormLogin() => Txt_Title_Form_Login;
        public IWebElement GetWebElementInptNombreUsuario() => Inpt_Nombre_Usuario;
        public IWebElement GetWebElementInptContrasennaUsuario() => Inpt_Contrasenna_Usuario;
        public IWebElement GetWebElementBtn_IngresarFormLogin() => Btn_Ingresar_Form_Login;
        public IWebElement GetWebElementTitleProducto() => Txt_Title_Producto; 

        /////
        //public IWebElement GetWebElementBtn_Pruebas() => Btn_Pruebas;
    }
}
