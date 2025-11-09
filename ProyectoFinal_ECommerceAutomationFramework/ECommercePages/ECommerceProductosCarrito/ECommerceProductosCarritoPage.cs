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

        public void HacerClicIconoCarrito()
        {
            _productosCarritoWaits.UsarElementToBeClickable(_productosCarritoComponents.GetByCartLink());
            _productosCarritoComponents.GetWebElementCartLink().Click();
        }

        public void Assert_TituloConfirmacionCarritoPaginaWeb(string assert_title_cart)
        {
            _productosCarritoWaits.UsarElementExists(_productosCarritoComponents.GetByTitleCart());
            Assert.That(_productosCarritoComponents.GetWebElementTitleCart().Text, Is.EqualTo(assert_title_cart));
        }

        public int GetCartCount()
        {
            // Wait for cart items to exist
            _productosCarritoWaits.UsarElementExists(_productosCarritoComponents.GetByCartProducts());

            // Count items found
            var cartItemsCount = _driver.FindElements(_productosCarritoComponents.GetByCartProducts()).Count;

            return cartItemsCount;
        }

        public void RemoveProductsFromCart()
        {
            var items = _driver.FindElements(_productosCarritoComponents.GetByCartProducts());
            if (items.Count == 0)
                throw new Exception("El carrito está vacío");

            var firstItem = items[0];
            var btn = firstItem.FindElement(_productosCarritoComponents.GetByRemoveButtons());
            btn.Click();

        }


    }
}
