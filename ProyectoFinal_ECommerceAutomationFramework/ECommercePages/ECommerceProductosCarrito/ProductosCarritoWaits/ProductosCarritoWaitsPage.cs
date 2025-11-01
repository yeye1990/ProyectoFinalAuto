using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Wait;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoWaits
{
    internal class ProductosCarritoWaitsPage
    {
        private readonly IWebDriver _driver;
        private readonly WaitBase _wait;

        public ProductosCarritoWaitsPage(IWebDriver drive) {
            _driver = drive;
            _wait = new WaitBase(drive);
        }
    }
}
