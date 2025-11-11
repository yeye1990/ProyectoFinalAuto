using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoActions
{
    internal class ProductosCarritoActionsPage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _action;
        private readonly int moverPixeles = 300;
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

        public void UsarScrollToElementDownPixeles()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0, {moverPixeles});");
        }

    }
}
