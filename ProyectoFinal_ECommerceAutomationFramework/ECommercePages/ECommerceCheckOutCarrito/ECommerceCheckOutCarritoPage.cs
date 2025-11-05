using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito.CheckOutCarritoActios;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito.CheckOutCarritoComponents;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito.CheckOutCarritoWaits;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Screenshot;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito
{
    public class ECommerceCheckOutCarritoPage
    {
        private readonly IWebDriver _driver;
        private readonly CheckOutCarritoComponentsPage _checkOutCarritoComponents;
        private readonly CheckOutCarritoWaitsPage _checkOutCarritoWaits;
        private readonly CheckOutCarritoActiosPage _checkOutCarritoActios;
        private readonly List<(string Nombre, string Precio)> _productosSeleccionados = new();
        private string? _carpetaEvidenciaActual;


        /// <summary>
        /// Constructor principal de la clase. Inicializa el driver y las páginas asociadas al flujo de checkout.
        /// </summary>
        public ECommerceCheckOutCarritoPage(IWebDriver driver)
        {
            _driver = driver;
            _checkOutCarritoComponents = new CheckOutCarritoComponentsPage(driver);
            _checkOutCarritoWaits = new CheckOutCarritoWaitsPage(driver);
            _checkOutCarritoActios = new CheckOutCarritoActiosPage(driver);
        }

        /// <summary>
        /// Ingresa las credenciales de usuario (nombre y contraseña) en el formulario de login.
        /// </summary>
        public void IngresarCredencialesLogin(string usuario, string contrasena) { 
            var loginPage = new ECommerceLoginPage(_driver);
            loginPage.IngresarCredenciales(usuario,contrasena);
        }

        /// <summary>
        /// Hace clic en el botón de login para iniciar sesión en el sistema.
        /// </summary>
        public void HacerClicBotónLogin() {
            var loginPage = new ECommerceLoginPage(_driver);
            loginPage.HacerClicBoton();
        }

        /// <summary>
        /// Agrega varios productos al carrito de compras según los índices indicados.
        /// Toma capturas de evidencia durante el proceso.
        /// </summary>
        public void AgregarProductosCarrito(List<int> indicesProductos)
        {
            foreach (var index in indicesProductos)
            {
                _checkOutCarritoComponents.SetIndexProducto(index);
                _checkOutCarritoActios.UsarMoveToElement(_checkOutCarritoComponents.GetWebElementLinkSeleccionarProducto());
                string nombre = _checkOutCarritoComponents.GetWebElementLinkSeleccionarProducto().Text;
                string precioTexto = _checkOutCarritoComponents.GetWebElementTxtPrecioProducto().Text;
                _productosSeleccionados.Add((nombre, precioTexto));
                _checkOutCarritoComponents.GetWebElementLinkSeleccionarProducto().Click();
                _checkOutCarritoComponents.GetWebElementBtnAgregarCarrito().Click();
                EjecutarCapturaEvidencia(_driver);
                _checkOutCarritoComponents.GetWebElementnLinkBackProducto().Click();
            }

        }

        /// <summary>
        /// Retorna la lista de productos seleccionados con su nombre y precio.
        /// </summary>
        public List<(string Nombre, string Precio)> GetProductosSeleccionados() => _productosSeleccionados;

        //Esto es para confirmar que en efecto si son productos diferentes los que se agregan al carrito
        //el assert funciona en reportar que no era el resultado esperado
        //
        //public List<(string Nombre, string Precio)> GetProductosSeleccionados()
        //{
        //    _productosSeleccionados.AddRange(new List<(string, string)> {
        //     ("Camisa Azul", "$25.00"),
        //     ("Pantalón Negro", "$40.00"),
        //     ("Zapatos Blancos", "$60.00")
        //    });

        //    return _productosSeleccionados;
        //}

        /// <summary>
        /// Busca un producto dentro del carrito y valida que coincida el nombre y el precio.
        /// </summary>
        public bool BuscarProductoCarrito(string nombre, string precio)
        {
            try
            {
                _checkOutCarritoComponents.SetNombreProducto(nombre);

                return _checkOutCarritoComponents.GetWebElementLblNombreProductoCarrito().Text.Trim().Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase) &&
                       _checkOutCarritoComponents.GetWebElementLblPrecioProductoCarrito().Text.Trim().Equals(precio.Trim(), StringComparison.OrdinalIgnoreCase);
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica que todos los productos seleccionados estén efectivamente presentes en el carrito.
        /// </summary>
        public bool Assert_VerificarProductosCarrito(List<(string Nombre, string Precio)> productos)
        {
            return productos.All(p => BuscarProductoCarrito(p.Nombre, p.Precio));
        }

        /// <summary>
        /// Hace clic en el ícono del carrito de compras para visualizar su contenido.
        /// </summary>
        public void HacerClicCarritoCompra()
        {
            _checkOutCarritoComponents.GetWebElementBtnCarritoCompra().Click();
        }

        /// <summary>
        /// Hace clic en el botón "Checkout" para iniciar el proceso de pago.
        /// Incluye espera explícita antes del clic.
        /// </summary>
        public void HacerClicBtnCheckout()
        {
            _checkOutCarritoActios.UsarScrollToElementDownPixeles();
            _checkOutCarritoWaits.UsarElementToBeClickable(_checkOutCarritoComponents.GetByBtnCheckout());
            _checkOutCarritoComponents.GetWebElementBtnCheckout().Click();
        }

        /// <summary>
        /// Obtiene y retorna el título del formulario de datos del cliente en la página de Checkout.
        /// </summary>
        public string Assert_TituloDatosClienteCheckOut()
        {
            _checkOutCarritoWaits.UsarElementIsVisible(_checkOutCarritoComponents.GetByTitleDatosClienteCheckOut());
            return _checkOutCarritoComponents.GetWebElementTitleDatosClienteCheckOut().Text;
        }

        /// <summary>
        /// Ingresa la información personal del cliente: nombre, apellido y código postal.
        /// </summary>
        public void IngresarDatosCliente(string nombre, string apellido, string codigoPostal)
        {
            _checkOutCarritoComponents.GetWebElementInptNombreCliente().SendKeys(nombre);
            _checkOutCarritoComponents.GetWebElementInptApellidoCliente().SendKeys(apellido);
            _checkOutCarritoComponents.GetWebElementInptCodigoPostalCliente().SendKeys(codigoPostal);
        }

        /// <summary>
        /// Hace clic en el botón "Continuar" para avanzar al siguiente paso del checkout.
        /// </summary>
        public void HacerClicBtnContinuar()
        {
            _checkOutCarritoComponents.GetWebElementBtnContinuarCheckout().Click();
        }

        /// <summary>
        /// Obtiene el título del resumen de compra antes de finalizar el proceso.
        /// </summary>
        public string Assert_TituloDesgloseCompraCheckOut()
        {
            _checkOutCarritoWaits.UsarElementIsVisible(_checkOutCarritoComponents.GetByTitleResumenCompra());
            return _checkOutCarritoComponents.GetWebElementTitleResumenCompra().Text;
        }

        /// <summary>
        /// Calcula la suma total de los productos agregados al carrito y la compara con el total mostrado en la página.
        /// </summary>
        public string Assert_VerificarTotalSumaProductos(List<(string Nombre, string Precio)> productos)
        {
            double total = 0;

            foreach (var producto in productos)
            {
                string precioLimpio = producto.Precio
                    .Replace("$", "")
                    .Replace(",", "")
                    .Trim();

                if (double.TryParse(precioLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out double precio))
                {
                    total += precio;
                }

            }

            string formatoTotal = total.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
            string totalMostrado = _checkOutCarritoComponents.GetWebElementLblTotalSumaProductos().Text.Replace("Item total: ",""); ;

            Assert.That(formatoTotal, Is.EqualTo(totalMostrado),$"El monto '{formatoTotal}' no coincide con el mostrado en la página '{totalMostrado}'.");

            return formatoTotal;
        }

        /// <summary>
        /// Calcula el monto total de compra incluyendo impuestos (8%) y lo compara con el mostrado en la página.
        /// </summary>
        public string Assert_VerificarMontoTotalCompra(List<(string Nombre, string Precio)> productos)
        {
            double total = 0;

            foreach (var producto in productos)
            {
                string precioLimpio = producto.Precio
                    .Replace("$", "")
                    .Replace(",", "")
                    .Trim();

                if (double.TryParse(precioLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out double precio))
                {
                    total += (precio * 1.08); 
                }

            }

            string formatoTotal = total.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
            string totalMostrado = _checkOutCarritoComponents.GetWebElementLblMontoTotalCompra().Text.Replace("Total: ", ""); ;

            Assert.That(formatoTotal, Is.EqualTo(totalMostrado),$"El monto '{formatoTotal}' no coincide con el mostrado en la página '{totalMostrado }'.");

            return formatoTotal;
        }

        /// <summary>
        /// Hace clic en el botón "Finalizar" para completar la compra.
        /// </summary>
        public void HacerClicBtnFinalizarCompra()
        {
            _checkOutCarritoActios.UsarScrollToElementDownPixeles();
            _checkOutCarritoWaits.UsarElementToBeClickable(_checkOutCarritoComponents.GetByBtnFinalizarCompra());
            _checkOutCarritoComponents.GetWebElementBtnFinalizarCompra().Click();
        }

        /// <summary>
        /// Retorna el mensaje de confirmación que se muestra tras finalizar la compra.
        /// </summary>
        public string Assert_MensajeConfirmacionCompraCheckOut()
        {
            _checkOutCarritoWaits.UsarElementIsVisible(_checkOutCarritoComponents.GetByLblMensajeConfirmacionCompra());
            return _checkOutCarritoComponents.GetWebElementLblMensajeConfirmacionCompra().Text;
        }

        /// <summary>
        /// Captura una evidencia (screenshot) durante la ejecución del test.
        /// Crea una carpeta dinámica por ejecución y guarda la imagen con un nombre único.
        /// </summary>
        public void EjecutarCapturaEvidencia(IWebDriver driver)
        {
            //Espera implicita antes de la captura
            _checkOutCarritoWaits.EsperaCapturaPantalla();

            //Ruta base hasta LoginValido
            string baseFolder = Path.GetFullPath(
                Path.Combine(TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceCheckOutCarrito", "Screenshot", "CheckOut")
            );

            //Crear carpeta solo una vez por ejecución del test
            if (string.IsNullOrEmpty(_carpetaEvidenciaActual))
            {
                // Carpeta dinámica basada en fecha/hora
                string folderName = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");

                _carpetaEvidenciaActual = Path.GetFullPath(
                    Path.Combine(baseFolder, folderName)
                );

                if (!Directory.Exists(_carpetaEvidenciaActual))
                    Directory.CreateDirectory(_carpetaEvidenciaActual);
            }

            //Nombre único del archivo
            string nombreArchivo = $"Evidencia_CheckOut_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            //Ruta completa final
            string fullPath = Path.GetFullPath(
                Path.Combine(_carpetaEvidenciaActual, nombreArchivo)
            );

            //Toma la captura
            ScreenshotBase.TakeScreenshot(driver, fullPath);
        }

    }
}
