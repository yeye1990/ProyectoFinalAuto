using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito.CheckOutCarritoActios
{
    internal class CheckOutCarritoActiosPage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _action;
        private readonly int moverPixeles = 300;

        public CheckOutCarritoActiosPage(IWebDriver driver)
        {
            _driver = driver;
            _action = new Actions(driver);
        }
        public void UsarScrollToElement(IWebElement elemento)
        {
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

        public void UsarScrollToElementDownPixeles()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0, {moverPixeles});");
        }
    }
}
