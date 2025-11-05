using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoComponents
{
    internal class ProductosCarritoComponentsPage
    {
        private readonly IWebDriver _driver;

        public ProductosCarritoComponentsPage(IWebDriver driver) {
            _driver = driver;
        }
    }
}
