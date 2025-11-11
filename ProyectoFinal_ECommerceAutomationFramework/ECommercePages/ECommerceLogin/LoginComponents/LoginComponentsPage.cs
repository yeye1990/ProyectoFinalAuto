using OpenQA.Selenium;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginComponents
{
    internal class LoginComponentsPage
    {
        private readonly IWebDriver _driver;
        public LoginComponentsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Definición de los localizadores By y WebElement 
        private readonly By _txtTitleFormLogin = By.CssSelector("div.login_logo");
        public By GetByTitleFormLogin() => _txtTitleFormLogin;
        private IWebElement Txt_Title_Form_Login => _driver.FindElement(_txtTitleFormLogin);
        public IWebElement GetWebElementTitleFormLogin() => Txt_Title_Form_Login;


        // Definición de los localizadores By y WebElement 
        private readonly By _inptNombreUsuario = By.Id("user-name");
        public By GetByNombreUsuario() => _inptNombreUsuario;
        private IWebElement Inpt_Nombre_Usuario => _driver.FindElement(_inptNombreUsuario);
        public IWebElement GetWebElementInptNombreUsuario() => Inpt_Nombre_Usuario;


        // Definición de los localizadores By y WebElement 
        private readonly By _inptContrasennaUsuario = By.Id("password");
        public By GetByContrasennaUsuario() => _inptContrasennaUsuario;
        private IWebElement Inpt_Contrasenna_Usuario => _driver.FindElement(_inptContrasennaUsuario);
        public IWebElement GetWebElementInptContrasennaUsuario() => Inpt_Contrasenna_Usuario;


        // Definición de los localizadores By y WebElement 
        private readonly By _btnIngresarFormLogin = By.Id("login-button");
        public By GetByBtnIngresarFormLogin() => _btnIngresarFormLogin;
        private IWebElement Btn_Ingresar_Form_Login => _driver.FindElement(_btnIngresarFormLogin);
        public IWebElement GetWebElementBtn_IngresarFormLogin() => Btn_Ingresar_Form_Login;


        // Definición de los localizadores By y WebElement 
        private readonly By _txtTitleProductos = By.CssSelector("div span.title");
        public By GetByTitleProductos() => _txtTitleProductos;
        private IWebElement Txt_Title_Producto => _driver.FindElement(_txtTitleProductos);
        public IWebElement GetWebElementTitleProducto() => Txt_Title_Producto;


        // Definición de los localizadores By y WebElement 
        private readonly By _txtMensajeErrorLogin = By.CssSelector("h3[data-test='error']");
        public By GetByMensajeErrorLogin() => _txtMensajeErrorLogin;
        private IWebElement Txt_Mensaje_Error_Login => _driver.FindElement(_txtMensajeErrorLogin);
        public IWebElement GetWebElementMensajeErrorLogin() => Txt_Mensaje_Error_Login;

    }
}
