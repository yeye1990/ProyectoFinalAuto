using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoComponents
{
    public class ProductosCarritoComponentsPage
    {
        private readonly IWebDriver _driver;
        public ProductosCarritoComponentsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Definición de los localizadores By y WebElement
        private By _cartLink => By.CssSelector("[data-test='shopping-cart-link']");
        public By GetByCartLink() => _cartLink;
        private IWebElement Cart_Link => _driver.FindElement(_cartLink);
        public IWebElement GetWebElementCartLink() => Cart_Link;

        // Definición de los localizadores By y WebElement
        private readonly By _txtTitleCart = By.CssSelector("[data-test='title']");
        public By GetByTitleCart() => _txtTitleCart;
        private IWebElement Txt_Title_Cart => _driver.FindElement(_txtTitleCart);
        public IWebElement GetWebElementTitleCart() => Txt_Title_Cart;

        // Definición de los localizadores By y WebElement
        private By _cartProducts => By.CssSelector(".cart_item");
        public By GetByCartProducts() => _cartProducts;
        private IWebElement Cart_Products => _driver.FindElement(_cartProducts);
        public IWebElement GetWebElementCartProducts() => Cart_Products;

        // Definición de los localizadores By y WebElement
        private By _removeButtons => By.CssSelector("button[data-test^='remove']");
        public By GetByRemoveButtons() => _removeButtons;
        private IWebElement Remove_Buttons => _driver.FindElement(_removeButtons);
        public IWebElement GetWebElementRemoveButtons() => Remove_Buttons;

       



    }
}
