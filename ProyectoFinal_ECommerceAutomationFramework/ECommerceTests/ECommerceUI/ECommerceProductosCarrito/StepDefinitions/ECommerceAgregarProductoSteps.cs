using Reqnroll;
using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceProductosCarrito.StepDefinitions
{
    [Binding]
    public class ECommerceAgregarProductoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private ECommerceProductosCarritoPage _productosCarritoPage;
        private ECommerceLoginPage _loginPage;

        public ECommerceAgregarProductoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _productosCarritoPage = new ECommerceProductosCarritoPage(_driver);
            _loginPage = new ECommerceLoginPage(_driver);
        }

        /// <summary>
        /// Realiza el proceso de inicio de sesión ingresando credenciales válidas
        /// y accediendo exitosamente a la aplicación.
        /// </summary>
        //Background
        [Given (@"The user logs into the system with valid credentials")]
        public void GivenTheUserLogsIntoTheSystemWithValidCredentials()
        {
            var data = ECommerceLogin.Data.DataLoginValido.GetJsonDataLoginValido().First();
            string usuario = data.Arguments[0]!.ToString()!;
            string contrasena = data.Arguments[1]!.ToString()!;
            _loginPage.IngresarCredenciales(usuario, contrasena);
            _productosCarritoPage.EjecutarCapturaEvidencia(_driver);
            _loginPage.HacerClicBoton();
        }

        /// <summary>
        /// Step que simula la acción del usuario de seleccionar cada uno de los productos que desea comprar desde la lista disponible.
        /// Los datos de los productos y la evidencia se obtienen del primer registro del archivo JSON a través de la clase DataAgregarProductosCarrito.
        /// </summary>
        //Scenario
        [Given (@"The user selects each product they want to purchase from the list")]
        public void GivenTheUserSelectsEachProductTheyWantToPurchaseFromTheList()
        {
            var data = Data.DataAgregarProductosCarrito.GetJsonDataAgregarProductos().First();
            List<int> lproductos = (List<int>)data.Arguments[2]!;
            string evidencia = data.Arguments[3]!.ToString()!;
            _productosCarritoPage.AgregarProductosCarrito(lproductos, evidencia);
        }

        /// <summary>
        /// Selecciona los productos indicados en los datos de prueba para agregarlos al carrito de compras.
        /// </summary>
        [When(@"The user finishes adding the products and clicks the shopping cart button")]
        public void WhenTheUserFinishesAddingTheProductsAndClicksTheShoppingCartButton()
        {
            _productosCarritoPage.HacerClicCarritoCompra();
        }

        /// <summary>
        /// Verifica que los productos agregados al carrito coincidan con los productos seleccionados durante la prueba.
        /// </summary>
        [Then(@"The user can verify each product added to the shopping cart")]
        public void ThenTheUserCanVerifyEachProductAddedToTheShoppingCart()
        {
            _productosCarritoPage.EjecutarCapturaEvidencia(_driver);
            bool assert_productos_carrito = _productosCarritoPage.Assert_VerificarProductosCarrito(_productosCarritoPage.GetProductosSeleccionados());
            if (!assert_productos_carrito)
            {
                throw new System.Exception($"El error se presenta porque los productos verificados no coinciden con los seleccionados para la prueba, por favor examina la lista de productos: {string.Join(", ", _productosCarritoPage.GetProductosSeleccionados())}" + ", y así podrás encontrar la diferencia");
            }
        }

    }
}
