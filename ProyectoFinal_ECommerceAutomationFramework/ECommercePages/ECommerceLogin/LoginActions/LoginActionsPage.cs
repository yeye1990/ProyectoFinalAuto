using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginActions
{
    internal class LoginActionsPage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _action;

        public LoginActionsPage(IWebDriver driver) {
            _driver = driver;
            _action = new Actions(driver);
        }

        public void UsarScrollToElement(IWebElement elemento) {
            _action.ScrollToElement(elemento).Perform();
        }

        public void UsarMoveToElement(IWebElement elemento)
        {
            _action.MoveToElement(elemento).Perform();
        }

        public void UsarDoubleClick(IWebElement elemento)
        {
            _action.DoubleClick(elemento).Perform();
        }

    }
}
