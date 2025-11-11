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
        private int _indexProducto;
        private string _nombreProducto;

        public ProductosCarritoComponentsPage(IWebDriver driver) {
            _driver = driver;
        }

        public void SetIndexProducto(int indexProducto)
        {
            _indexProducto = indexProducto;
        }

        public void SetNombreProducto(string nombreProducto)
        {
            _nombreProducto = nombreProducto;
        }

        private By _linkSeleccionarProducto => By.XPath($"(//div[contains(@class,'inventory_item_name ')]) [{_indexProducto}]");
        public By GetByLinkSeleccionarProducto() => _linkSeleccionarProducto;
        private IWebElement Link_Seleccionar_Producto => _driver.FindElement(_linkSeleccionarProducto);
        public IWebElement GetWebElementLinkSeleccionarProducto() => Link_Seleccionar_Producto;

        private By _txtPrecioProducto => By.XPath($"(//div[contains(@class,'inventory_item_price')]) [{_indexProducto}]");
        public By GetByTxtPrecioProducto() => _txtPrecioProducto;
        private IWebElement Txt_Precio_Producto => _driver.FindElement(_txtPrecioProducto);
        public IWebElement GetWebElementTxtPrecioProducto() => Txt_Precio_Producto;

        private By _btnAgregarCarrito => By.Id("add-to-cart");
        public By GetByBtnAgregarCarrito() => _btnAgregarCarrito;
        private IWebElement Btn_Agregar_Carrito => _driver.FindElement(_btnAgregarCarrito);
        public IWebElement GetWebElementBtnAgregarCarrito() => Btn_Agregar_Carrito;

        private By _linkBackProducto => By.Id("back-to-products");
        public By GetByLinkBackProducto() => _linkBackProducto;
        private IWebElement Link_Back_Producto => _driver.FindElement(_linkBackProducto);
        public IWebElement GetWebElementnLinkBackProducto() => Link_Back_Producto;

        private By _lblNombreProductoCarrito => By.XPath($"//div[@class='inventory_item_name' and text()='{_nombreProducto}']");
        public By GetByLblNombreProductoCarrito() => _lblNombreProductoCarrito;
        private IWebElement Lbl_Nombre_Producto_Carrito => _driver.FindElement(_lblNombreProductoCarrito);
        public IWebElement GetWebElementLblNombreProductoCarrito() => Lbl_Nombre_Producto_Carrito;

        private By _lblPrecioProductoCarrito => By.XPath($"//div[@class='inventory_item_name' and text()='{_nombreProducto}']/ancestor::div[@class='cart_item']//div[@class='inventory_item_price']");
        public By GetByLblPrecioProductoCarrito() => _lblPrecioProductoCarrito;
        private IWebElement Lbl_Precio_Producto_Carrito => _driver.FindElement(_lblPrecioProductoCarrito);
        public IWebElement GetWebElementLblPrecioProductoCarrito() => Lbl_Precio_Producto_Carrito;

        private By _btnCarritoCompra => By.CssSelector("a.shopping_cart_link");
        public By GetByBtnCarritoCompra() => _btnCarritoCompra;
        private IWebElement Btn_Carrito_Compra => _driver.FindElement(_btnCarritoCompra);
        public IWebElement GetWebElementBtnCarritoCompra() => Btn_Carrito_Compra;

        private By _btnEliminarProductoCarrito => By.XPath($"//div[@class='inventory_item_name' and text()='{_nombreProducto}']/ancestor::div[@class='cart_item']//button[@class='btn btn_secondary btn_small cart_button']");
        public By GetByBtnEliminarProductoCarrito() => _btnEliminarProductoCarrito;
        private IWebElement Btn_Eliminar_Producto_Carrito => _driver.FindElement(_btnEliminarProductoCarrito);
        public IWebElement GetWebElementBtnEliminarProductoCarrito() => Btn_Eliminar_Producto_Carrito;

        private By _btnRegresarPaginaPrincipal  => By.Id("continue-shopping");
        public By GetByBtnRegresarPaginaPrincipal() => _btnRegresarPaginaPrincipal;
        private IWebElement Btn_Regresar_Pagina_Principal => _driver.FindElement(_btnRegresarPaginaPrincipal);
        public IWebElement GetWebElementBtnRegresarPaginaPrincipal() => Btn_Regresar_Pagina_Principal;


        // Definición de los localizadores By y WebElement
        private By _removeButtons => By.CssSelector("button[data-test^='remove']");
        public By GetByRemoveButtons() => _removeButtons;
        private IWebElement Remove_Buttons => _driver.FindElement(_removeButtons);
        public IWebElement GetWebElementRemoveButtons() => Remove_Buttons;




    }
}
