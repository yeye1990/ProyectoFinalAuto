using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoActions
{
    internal class ProductosCarritoActionsPage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _action;
        public ProductosCarritoActionsPage(IWebDriver driver) {
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
    }
}
