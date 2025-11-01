using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoActions;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoComponents;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoWaits;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito
{
    public class ECommerceProductosCarritoPage
    {
        private readonly IWebDriver _driver;
        private readonly ProductosCarritoActionsPage _productosCarritoActions;
        private readonly ProductosCarritoComponentsPage _productosCarritoComponents;
        private readonly ProductosCarritoWaitsPage _productosCarritoWaits;

        public ECommerceProductosCarritoPage(IWebDriver driver) {
            _driver = driver;
            _productosCarritoActions = new ProductosCarritoActionsPage(driver);
            _productosCarritoComponents = new ProductosCarritoComponentsPage(driver);
            _productosCarritoWaits = new ProductosCarritoWaitsPage(driver);
        }
    }
}
