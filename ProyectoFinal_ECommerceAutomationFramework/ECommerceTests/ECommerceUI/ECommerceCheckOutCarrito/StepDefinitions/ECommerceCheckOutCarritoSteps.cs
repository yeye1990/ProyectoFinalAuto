using Reqnroll;
using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceCheckOutCarrito.Data;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceCheckOutCarrito.StepDefinitions
{
    [Binding]
    public class ECommerceCheckOutCarritoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly ECommerceProductosCarritoPage _productosCarritoPage;
        private readonly ECommerceCheckOutCarritoPage _checkOutCarritoPage;
        private readonly ECommerceLoginPage _loginPage;

        public ECommerceCheckOutCarritoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _productosCarritoPage = new ECommerceProductosCarritoPage(_driver);
            _checkOutCarritoPage = new ECommerceCheckOutCarritoPage(_driver);
            _loginPage = new ECommerceLoginPage(_driver);
        }

        /// <summary>
        /// Realiza el inicio de sesión utilizando credenciales válidas obtenidas desde la fuente de datos JSON.
        /// Este método toma el primer registro disponible de los datos de prueba, extrae el usuario y la contraseña,
        /// los ingresa en el formulario de inicio de sesión y hace clic en el botón para acceder al sistema.
        /// </summary>
        /// <remarks>
        /// Se utiliza normalmente en el Background de los escenarios donde se requiere que el usuario ya haya iniciado sesión
        /// antes de continuar con las acciones de la prueba.
        /// Garantiza que el flujo de prueba comience con una sesión válida.
        /// </remarks>
        //Background:
        [Given (@"The user logs into the system with valid credential")]
        public void GivenTheUserLogsIntoTheSystemWithValidCredential()
        {
            var data = DataLoginValido.GetJsonDataLoginValido().First();
            string usuario = data.Arguments[0]!.ToString()!;
            string contrasena = data.Arguments[1]!.ToString()!;
            _loginPage.IngresarCredenciales(usuario, contrasena);
            _checkOutCarritoPage.EjecutarCapturaEvidencia(_driver);
            _loginPage.HacerClicBoton();
        }

        /// <summary>
        /// Agrega los productos al carrito con base en la lista definida en los datos de prueba JSON.
        /// Este método obtiene el conjunto de índices de productos a agregar, los envía a la página correspondiente
        /// para que sean seleccionados y posteriormente accede al carrito de compras.
        /// </summary>
        /// <remarks>
        /// Este paso se utiliza para preparar el flujo de compra, asegurando que los productos requeridos
        /// estén disponibles en el carrito antes de continuar hacia el proceso de checkout.
        /// </remarks>
        [Then (@"The user adds products to the cart in order to make a purchase")]
        public void ThenTheUserAddsProductsToTheCartInOrderToMakeAPurchase()
        {
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            List<int> lproductos = (List<int>)data.Arguments[2]!;
            string evidencia = data.Arguments[11]!.ToString()!;
            _productosCarritoPage.AgregarProductosCarrito(lproductos, evidencia);
            _productosCarritoPage.HacerClicCarritoCompra();
        }

        /// <summary>
        /// Permite continuar con el proceso de compra luego de que el usuario ya ha seleccionado
        /// los productos y está listo para iniciar el proceso de checkout.
        /// Este método realiza el clic en el botón "Checkout" desde el carrito de compras.
        /// </summary>
        //Scenario:
        [Given (@"The user has selected the products and clicks the ""Checkout"" button")]
        public void GivenTheUserHasSelectedTheProductsAndClicksTheCheckoutButton()
        {
            _checkOutCarritoPage.EjecutarCapturaEvidencia(_driver);
            _checkOutCarritoPage.HacerClicBtnCheckout();
        }

        /// <summary>
        /// Verifica que, al iniciar el proceso de checkout, se muestre correctamente
        /// la pantalla donde el usuario debe ingresar su información personal.
        /// </summary>
        [Then (@"The user should see the screen with the title ""Checkout: Your Information""")]
        public void ThenTheUserShouldSeeTheScreenWithTheTitleCheckoutYourInformation()
        {
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            string assertTituloDatosClienteCheckOut = data.Arguments[6]!.ToString()!;

            Assert.That(_checkOutCarritoPage.Assert_TituloDatosClienteCheckOut(), Is.EqualTo(assertTituloDatosClienteCheckOut));
        }

        /// <summary>
        /// Ingresa la información personal requerida por el sistema para continuar con el proceso de compra.
        /// </summary>
        [When (@"The user enters their required personal information for the checkout")]
        public void WhenTheUserEntersTheirRequiredPersonalInformationForTheCheckout()
        {
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            string nombre = data.Arguments[3]!.ToString()!;
            string apellido = data.Arguments[4]!.ToString()!;
            string codigoPostal = data.Arguments[5]!.ToString()!;
            _checkOutCarritoPage.IngresarDatosCliente(nombre, apellido, codigoPostal);
        }

        /// <summary>
        /// Realiza la acción de continuar con el proceso de compra.
        /// </summary>
        [When (@"The user clicks the ""Continue"" button")]
        public void WhenTheUserClicksTheContinueButton()
        {
            _checkOutCarritoPage.EjecutarCapturaEvidencia(_driver);
            _checkOutCarritoPage.HacerClicBtnContinuar();
        }

        /// <summary>
        /// Verifica que se muestre correctamente la pantalla de resumen del Checkout.
        /// </summary>
        [Then (@"The user should see the screen with the title ""Checkout: Overview""")]
        public void ThenTheUserShouldSeeTheScreenWithTheTitleCheckoutOverview()
        {
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            string assertTituloDesgloseCompraCheckOut = data.Arguments[7]!.ToString()!;

            Assert.That(_checkOutCarritoPage.Assert_TituloDatosClienteCheckOut(), Is.EqualTo(assertTituloDesgloseCompraCheckOut));
        }

        /// <summary>
        /// Verifica que la suma total de los productos agregados al carrito sea correcta.
        /// </summary>
        [Then (@"The user should verify the total sum of the products")]
        public void ThenTheUserShouldVerifyTheTotalSumOfTheProducts()
        {
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            string expectedTotalProducts = data.Arguments[8]!.ToString()!;
            string actualTotalProducts = _checkOutCarritoPage.Assert_VerificarTotalSumaProductos(_productosCarritoPage.GetProductosSeleccionados());

            Assert.That(actualTotalProducts, Is.EqualTo(expectedTotalProducts));
        }

        /// <summary>
        /// Verifica que el monto total de la compra, incluyendo el impuesto, sea correcto.
        /// </summary>
        [Then (@"The user should verify the total amount including tax")]
        public void ThenTheUserShouldVerifyTheTotalAmountIncludingTax()
        {
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            string expectedTotalAmount = data.Arguments[9]!.ToString()!;
            string actualTotalAmount = _checkOutCarritoPage.Assert_VerificarMontoTotalCompra(_productosCarritoPage.GetProductosSeleccionados());

            Assert.That(actualTotalAmount, Is.EqualTo(expectedTotalAmount));
        }

        /// <summary>
        /// Finaliza el proceso de compra en la aplicación.
        /// </summary>
        [When (@"The user clicks the ""Finish"" button")]
        public void WhenTheUserClicksTheFinishButton()
        {
            _checkOutCarritoPage.EjecutarCapturaEvidencia(_driver);
            _checkOutCarritoPage.HacerClicBtnFinalizarCompra();
        }

        /// <summary>
        /// Verifica que la pantalla muestre el mensaje de confirmación de compra exitosa.
        /// </summary>
        [Then (@"The user should see the screen with the message ""Thank you for your order!""")]
        public void ThenTheUserShouldSeeTheScreenWithTheMessageThankYouForYourOrder()
        {
            _checkOutCarritoPage.EjecutarCapturaEvidencia(_driver);
            var data = DataCheckOutCarritoExitoso.GetJsonDataCheckOut().First();
            string assertMensajeConfirmacionCompraCheckOut = data.Arguments[10]!.ToString()!;

            Assert.That(_checkOutCarritoPage.Assert_MensajeConfirmacionCompraCheckOut(), Is.EqualTo(assertMensajeConfirmacionCompraCheckOut));
        }
    }
}
