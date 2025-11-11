using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoActions;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoComponents;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito.ProductosCarritoWaits;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Screenshot;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito
{
    public class ECommerceProductosCarritoPage
    {
        private readonly IWebDriver _driver;
        private readonly ProductosCarritoActionsPage _productosCarritoActions;
        private readonly ProductosCarritoComponentsPage _productosCarritoComponents;
        private readonly ProductosCarritoWaitsPage _productosCarritoWaits;
        private readonly List<(string Nombre, string Precio)> _productosSeleccionados = new();
        private readonly ECommerceCheckOutCarritoPage _checkOutCarritoPage;
        private string? _carpetaEvidenciaActual;

        public ECommerceProductosCarritoPage(IWebDriver driver) {
            _driver = driver;
            _productosCarritoActions = new ProductosCarritoActionsPage(driver);
            _productosCarritoComponents = new ProductosCarritoComponentsPage(driver);
            _productosCarritoWaits = new ProductosCarritoWaitsPage(driver);
            _checkOutCarritoPage = new ECommerceCheckOutCarritoPage(driver);
        }

        /// <summary>
        /// Agrega varios productos al carrito de compras según los índices indicados.
        /// Toma capturas de evidencia durante el proceso.
        /// </summary>
        public void AgregarProductosCarrito(List<int> indicesProductos, string evidencia)
        {
            foreach (var index in indicesProductos)
            {
                _productosCarritoComponents.SetIndexProducto(index);
                string nombre = _productosCarritoComponents.GetWebElementLinkSeleccionarProducto().Text;
                string precioTexto = _productosCarritoComponents.GetWebElementTxtPrecioProducto().Text;
                _productosSeleccionados.Add((nombre, precioTexto));
                _productosCarritoComponents.GetWebElementLinkSeleccionarProducto().Click();
                _productosCarritoComponents.GetWebElementBtnAgregarCarrito().Click();

                if (evidencia.Equals("CheckOut")) { 
                    _checkOutCarritoPage.EjecutarCapturaEvidenciaAgregarCarrito(_driver, evidencia);
                } else {
                    EjecutarCapturaEvidencia(_driver);
                } 
                    
                _productosCarritoComponents.GetWebElementnLinkBackProducto().Click();
            }

        }

        /// <summary>
        /// Retorna la lista de productos seleccionados con su nombre y precio.
        /// </summary>
       public List<(string Nombre, string Precio)> GetProductosSeleccionados() => _productosSeleccionados;

        //Esto es para confirmar que en efecto si son productos diferentes los que se agregan al carrito
        //el assert funciona en reportar que no era el resultado esperado
        //public List<(string Nombre, string Precio)> GetProductosSeleccionados()
        //{
        //    _productosSeleccionados.AddRange(new List<(string, string)> {
        //     ("Sauce Labs Fleece Jacket", "$49.99"),
        //     ("Sauce Labs Onesie", "$7.99"),
        //     ("Test.allTheThings() T-Shirt (Red)", "$15.99")
        //    });

        //    return _productosSeleccionados;
        //}

        // <summary>
        // Busca un producto dentro del carrito y valida que coincida el nombre y el precio.
        // </summary>
        public bool BuscarProductoCarrito(string nombre, string precio)
        {
            try
            {
                _productosCarritoComponents.SetNombreProducto(nombre);

                return _productosCarritoComponents.GetWebElementLblNombreProductoCarrito().Text.Trim().Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase) &&
                       _productosCarritoComponents.GetWebElementLblPrecioProductoCarrito().Text.Trim().Equals(precio.Trim(), StringComparison.OrdinalIgnoreCase);
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
            _productosCarritoComponents.GetWebElementBtnCarritoCompra().Click();
        }

        /// <summary>
        /// Busca un producto dentro del carrito y valida que coincida el nombre y el precio.
        /// Si el producto existe, hace clic en el botón eliminar.
        /// </summary>
        public bool EliminarProductoCarrito(string nombre, string precio)
        {
            try
            {
                _productosCarritoComponents.SetNombreProducto(nombre);

                bool nombreCoincide = _productosCarritoComponents.GetWebElementLblNombreProductoCarrito().Text.Trim().Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase);

                bool precioCoincide = _productosCarritoComponents.GetWebElementLblPrecioProductoCarrito().Text.Trim().Equals(precio.Trim(), StringComparison.OrdinalIgnoreCase);

                if (nombreCoincide && precioCoincide)
                {
                    // Si el producto coincide, eliminarlo
                    EjecutarCapturaEvidenciaEliminarProducto(_driver);
                    _productosCarritoComponents.GetWebElementBtnEliminarProductoCarrito().Click();
                    return true;
                }

                return false;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica y elimina todos los productos indicados del carrito.
        /// Retorna true si todos fueron eliminados correctamente.
        /// </summary>
        public bool Assert_VerificarProductosEliminadoCarrito(List<(string Nombre, string Precio)> productos)
        {
            return productos.All(p => EliminarProductoCarrito(p.Nombre, p.Precio));
        }

        /// <summary>
        /// Navega de regreso a la página principal de productos desde el carrito,
        /// haciendo clic en el botón "Continue Shopping" (Regresar).
        /// </summary>
        public void RegresarPaginaPrincipal()
        {
            _productosCarritoComponents.GetWebElementBtnRegresarPaginaPrincipal().Click();
        }

        /// <summary>
        /// Captura una evidencia (screenshot) durante la ejecución del test.
        /// Crea una carpeta dinámica por ejecución y guarda la imagen con un nombre único.
        /// </summary>
        public void EjecutarCapturaEvidencia(IWebDriver driver)
        {
            //Espera implicita antes de la captura
            _productosCarritoWaits.EsperaCapturaPantalla();

            //Ruta base hasta LoginValido
            string baseFolder = Path.GetFullPath(
                Path.Combine(TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceProductosCarrito", "Screenshot", "AgregarProducto")
            );

            //Crear carpeta solo una vez por ejecución del test
            if (string.IsNullOrEmpty(_carpetaEvidenciaActual))
            {
                // Carpeta dinámica basada en fecha/hora
                string folderName = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                _carpetaEvidenciaActual = Path.GetFullPath(
                    Path.Combine(baseFolder, folderName)
                );

                if (!Directory.Exists(_carpetaEvidenciaActual))
                    Directory.CreateDirectory(_carpetaEvidenciaActual);
            }

            //Nombre único del archivo
            string nombreArchivo = $"Evidencia_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            //Ruta completa final
            string fullPath = Path.GetFullPath(
                Path.Combine(_carpetaEvidenciaActual, nombreArchivo)
            );

            //Toma la captura
            ScreenshotBase.TakeScreenshot(driver, fullPath);
        }


        /// <summary>
        /// Captura una evidencia (screenshot) durante la ejecución del test.
        /// Crea una carpeta dinámica por ejecución y guarda la imagen con un nombre único.
        /// </summary>
        public void EjecutarCapturaEvidenciaEliminarProducto(IWebDriver driver)
        {
            //Espera implicita antes de la captura
            _productosCarritoWaits.EsperaCapturaPantalla();

            //Ruta base hasta LoginValido
            string baseFolder = Path.GetFullPath(
                Path.Combine(TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceProductosCarrito", "Screenshot", "EliminarProducto")
            );

            //Crear carpeta solo una vez por ejecución del test
            if (string.IsNullOrEmpty(_carpetaEvidenciaActual))
            {
                // Carpeta dinámica basada en fecha/hora
                string folderName = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                _carpetaEvidenciaActual = Path.GetFullPath(
                    Path.Combine(baseFolder, folderName)
                );

                if (!Directory.Exists(_carpetaEvidenciaActual))
                    Directory.CreateDirectory(_carpetaEvidenciaActual);
            }

            //Nombre único del archivo
            string nombreArchivo = $"Evidencia_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.png";

            //Ruta completa final
            string fullPath = Path.GetFullPath(
                Path.Combine(_carpetaEvidenciaActual, nombreArchivo)
            );

            //Toma la captura
            ScreenshotBase.TakeScreenshot(driver, fullPath);
        }

        public int GetRemoveButtons()
        {
            
            // Count items found
            var cant_remove_bt = _driver.FindElements(_productosCarritoComponents.GetByRemoveButtons()).Count;

            return cant_remove_bt;
        }

        public bool IsCartEmpty()
        {
            return GetRemoveButtons() == 0;
        }


    }
}
