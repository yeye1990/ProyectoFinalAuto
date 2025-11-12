using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using Reqnroll;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.StepDefinitions
{
    [Binding]
    public class ECommerceLoginValidoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private ECommerceLoginPage _loginPage;

        public ECommerceLoginValidoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _loginPage = new ECommerceLoginPage(_driver);
        }

        /// <summary>
        /// Verifica que al cargar la página inicial se muestre el título correcto "Swag Labs".
        /// </summary>
        [Given (@"That when the page loads the user should see the title ""Swag Labs""")]
            public void GivenThatWhenThePageLoadsTheUserSeeTheTitleSwagLabs()
        {
            var data = DataLoginValido.GetJsonDataLoginValido().First();
            string tituloPagina = data.Arguments[3]!.ToString()!;
            _loginPage.Assert_TituloConfirmacionCargarPaginaWeb(tituloPagina);

        }

        /// <summary>
        /// Ingresa las credenciales válidas del usuario en el formulario de inicio de sesión.
        /// </summary>
        [When (@"The user enters valid credentials")]
        public void WhenTheUserEntersValidCredentialsUsernameAndPassword()
        {
            var data = DataLoginValido.GetJsonDataLoginValido().First();
            string usuario = data.Arguments[0]!.ToString()!;
            string contrasena = data.Arguments[1]!.ToString()!;            
            _loginPage.IngresarCredenciales(usuario,contrasena);
            _loginPage.EjecutarCapturaEvidencia(_driver);
        }

        /// <summary>
        /// Hace clic en el botón de inicio de sesión para ingresar al sistema.
        /// </summary>
        [When (@"The user Clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _loginPage.HacerClicBoton();
            _loginPage.EjecutarCapturaEvidencia(_driver);
        }

        /// <summary>
        /// Verifica que la página de productos se muestre con el título esperado "Products".
        /// </summary>
        [Then(@"The user should see the products page with the title ""Products""")]
        public void ThenUserShouldSeeTheProductsPageWithTheTitleProducts()
        {
            var data = DataLoginValido.GetJsonDataLoginValido().First();
            string assert_pass = data.Arguments[2]!.ToString()!;

            Assert.That(_loginPage.Assert_TituloConfirmacionIngreso(), Is.EqualTo(assert_pass));
        }
    }
}
