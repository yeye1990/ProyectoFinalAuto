using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Wait;
using SeleniumExtras.WaitHelpers;


namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin.LoginWaits
{
    internal class LoginWaitsPage 
    {
        private readonly IWebDriver _driver;
        private readonly WaitBase _wait;

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


    }
}
