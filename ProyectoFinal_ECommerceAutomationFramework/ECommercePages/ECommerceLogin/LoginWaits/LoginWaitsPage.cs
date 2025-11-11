using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Wait;
using SeleniumExtras.WaitHelpers;


namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginWaits
{
    internal class LoginWaitsPage 
    {
        private readonly IWebDriver _driver;
        private readonly WaitBase _wait;
        private readonly int milisegundos = 1000;

        public LoginWaitsPage(IWebDriver driver) {
            _driver = driver;
            _wait = new WaitBase(driver);
        }

        public void UsarElementExists(By locator) {
            _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void UsarElementIsVisible(By locator) {
            _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void UsarElementToBeClickable(By locator) {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void EsperaCapturaPantalla() {
            System.Threading.Thread.Sleep(milisegundos);
        }


    }
}
