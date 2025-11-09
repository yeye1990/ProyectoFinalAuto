using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginActions;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginComponents;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginWaits;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data;
using Reqnroll;
using Reqnroll.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.StepDefinitions
{
    [Binding]
    public class ECommerceLoginInvalidoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly ECommerceLoginPage _eCommerceLoginPage;
        private readonly LoginComponentsPage _loginComponentsPage;
        private readonly LoginWaitsPage _loginWaitsPage;
        

        public ECommerceLoginInvalidoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _eCommerceLoginPage = new ECommerceLoginPage(_driver);
            _loginComponentsPage = new LoginComponentsPage(_driver);
            _loginWaitsPage = new LoginWaitsPage(_driver);
        }


        [Given(@"The user is on the login page")]
        public void GivenTheUserIsOnTheHomePage()
        {
            Assert.That(_driver.Url, Does.Contain("saucedemo.com"));
        }

        [When(@"The user enters invalid username and password from testdata ""InvalidCredentials""")]
        public void WhenTheUserEnterInvalidCredentials()
        {
            //LoadTestData();
            var data=DataLoginInvalido.GetJsonDataLoginInvalido().First();
            string usuario = data.Arguments[0]!.ToString()!;
            string contrasena = data.Arguments[1]!.ToString()!;
            _eCommerceLoginPage.IngresarCredenciales(usuario, contrasena);
            Assert.Pass("Entered invalid credentials from test data.");
        }
        [When(@"The user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _eCommerceLoginPage.HacerClicBoton();
            Assert.Pass("Clicked the login button.");
        }
        [Then(@"An error message ""Epic sadface: Username and password do not match any user in this service"" should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed()
        {
            var data = DataLoginInvalido.GetJsonDataLoginInvalido().First();
            string msj_error = data.Arguments[2]!.ToString()!;
            _loginWaitsPage.UsarElementExists(_loginComponentsPage.GetByMensajeErrorLogin());
            string actualErrorMessage = _loginComponentsPage.GetWebElementMensajeErrorLogin().Text;
            Assert.That(actualErrorMessage, Is.EqualTo(msj_error), "The error message does not match the expected value.");
        }

    }
}
