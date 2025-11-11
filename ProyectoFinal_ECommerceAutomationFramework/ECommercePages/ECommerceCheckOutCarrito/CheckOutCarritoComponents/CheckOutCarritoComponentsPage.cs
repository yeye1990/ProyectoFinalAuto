using OpenQA.Selenium;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito.CheckOutCarritoComponents
{
    internal class CheckOutCarritoComponentsPage
    {
        private readonly IWebDriver _driver;
        private int _indexProducto;
        private string ?_nombreProducto;

        public CheckOutCarritoComponentsPage(IWebDriver driver) {
            _driver = driver;
        }

        private By _lblDetalleProducto => By.CssSelector("div.inventory_details_name.large_size");
        public By GetByLblDetalleProducto() => _lblDetalleProducto;
        private IWebElement Lbl_Detalle_Producto => _driver.FindElement(_lblDetalleProducto);
        public IWebElement GetWebElementLblDetalleProducto() => Lbl_Detalle_Producto;

        private By _lblDetallePrecio => By.CssSelector("div.inventory_details_price");
        public By GetByLblDetallePrecio() => _lblDetallePrecio;
        private IWebElement Lbl_Detalle_Precio => _driver.FindElement(_lblDetallePrecio);
        public IWebElement GetWebElementnLblDetallePrecio() => Lbl_Detalle_Precio;

        private By _btnCheckout => By.Id("checkout");
        public By GetByBtnCheckout() => _btnCheckout;
        private IWebElement Btn_Checkout => _driver.FindElement(_btnCheckout);
        public IWebElement GetWebElementBtnCheckout() => Btn_Checkout;

        private By _titleDatosClienteCheckOut => By.CssSelector("span.title");
        public By GetByTitleDatosClienteCheckOut() => _titleDatosClienteCheckOut;
        private IWebElement Title_Datos_Cliente_CheckOut => _driver.FindElement(_titleDatosClienteCheckOut);
        public IWebElement GetWebElementTitleDatosClienteCheckOut() => Title_Datos_Cliente_CheckOut;

        private By _inptNombreCliente => By.Id("first-name");
        public By GetByInptNombreCliente() => _inptNombreCliente;
        private IWebElement Inpt_Nombre_Cliente => _driver.FindElement(_inptNombreCliente);
        public IWebElement GetWebElementInptNombreCliente() => Inpt_Nombre_Cliente;

        private By _inptApellidoCliente => By.Id("last-name");
        public By GetByInptApellidoCliente() => _inptApellidoCliente;
        private IWebElement Inpt_Apellido_Cliente => _driver.FindElement(_inptApellidoCliente);
        public IWebElement GetWebElementInptApellidoCliente() => Inpt_Apellido_Cliente;

        private By _inptCodigoPostalCliente => By.Id("postal-code");
        public By GetByInptCodigoPostalCliente() => _inptCodigoPostalCliente;
        private IWebElement Inpt_Codigo_Postal_Cliente => _driver.FindElement(_inptCodigoPostalCliente);
        public IWebElement GetWebElementInptCodigoPostalCliente() => Inpt_Codigo_Postal_Cliente;

        private By _btnContinuarCheckout => By.Id("continue");
        public By GetByBtnContinuarCheckout() => _btnContinuarCheckout;
        private IWebElement Btn_Continuar_Checkout => _driver.FindElement(_btnContinuarCheckout);
        public IWebElement GetWebElementBtnContinuarCheckout() => Btn_Continuar_Checkout;

        private By _titleResumenCompra => By.CssSelector("span.title");
        public By GetByTitleResumenCompra() => _titleResumenCompra;
        private IWebElement Title_Resumen_Compra => _driver.FindElement(_titleResumenCompra);
        public IWebElement GetWebElementTitleResumenCompra() => Title_Resumen_Compra;

        private By _lblTotalSumaProductos => By.CssSelector(".summary_subtotal_label");
        public By GetByLblTotalSumaProductos() => _lblTotalSumaProductos;
        private IWebElement Lbl_Total_Suma_Productos => _driver.FindElement(_lblTotalSumaProductos);
        public IWebElement GetWebElementLblTotalSumaProductos() => Lbl_Total_Suma_Productos;

        private By lblMontoTotalCompra => By.CssSelector(".summary_total_label");
        public By GetByLblMontoTotalCompra() => lblMontoTotalCompra;
        private IWebElement Lbl_Monto_Total_Compra => _driver.FindElement(lblMontoTotalCompra);
        public IWebElement GetWebElementLblMontoTotalCompra() => Lbl_Monto_Total_Compra;

        private By _btnFinalizarCompra => By.Id("finish");
        public By GetByBtnFinalizarCompra() => _btnFinalizarCompra;
        private IWebElement Btn_Finalizar_Compra => _driver.FindElement(_btnFinalizarCompra);
        public IWebElement GetWebElementBtnFinalizarCompra() => Btn_Finalizar_Compra;

        private By lblMensajeConfirmacionCompra => By.CssSelector("h2.complete-header");
        public By GetByLblMensajeConfirmacionCompra() => lblMensajeConfirmacionCompra;
        private IWebElement Lbl_Mensaje_Confirmacion_Compra => _driver.FindElement(lblMensajeConfirmacionCompra);
        public IWebElement GetWebElementLblMensajeConfirmacionCompra() => Lbl_Mensaje_Confirmacion_Compra;

    }
}
