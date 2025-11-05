using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Wait;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito.CheckOutCarritoWaits
{
    internal class CheckOutCarritoWaitsPage
    {
        private readonly IWebDriver _driver;
        private readonly WaitBase _wait;
        private readonly int milisegundos = 1000;

        public CheckOutCarritoWaitsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitBase(driver);
        }

        public void UsarElementExists(By locator)
        {
            _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void UsarElementIsVisible(By locator)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void UsarElementToBeClickable(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void EsperaCapturaPantalla()
        {
            System.Threading.Thread.Sleep(milisegundos);
        }

    }
}
