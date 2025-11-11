using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito;
using Reqnroll;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceProductosCarrito.StepDefinitions
{
    [Binding]
    public class ECommerceEliminarProductoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private ECommerceProductosCarritoPage _productosCarritoPage;
        private ECommerceLoginPage _loginPage;


        public ECommerceEliminarProductoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
            _productosCarritoPage = new ECommerceProductosCarritoPage(_driver);
            _loginPage = new ECommerceLoginPage(_driver);

        }

        //Background
        [Given(@"The user logs into the system correctly")]
        public void GivenTheUserLogsIntoTheSystemWithValidCredentials()
        {
            var data = ECommerceLogin.Data.DataLoginValido.GetJsonDataLoginValido().First();
            string usuario = data.Arguments[0]!.ToString()!;
            string contrasena = data.Arguments[1]!.ToString()!;
            _loginPage.IngresarCredenciales(usuario, contrasena);
            _productosCarritoPage.EjecutarCapturaEvidenciaEliminarProducto(_driver);
            _loginPage.HacerClicBoton();
        }

        [Given(@"The user has added products to the cart")]
        public void GivenTheUserHasAddedProductsToTheCart()
        {
            _productosCarritoPage.AgregarProductosCarrito(new List<int> { 1, 2, 3 }, "Productos");
            _productosCarritoPage.EjecutarCapturaEvidenciaEliminarProducto(_driver);
        }
        [Given(@"The user clicks on the cart icon")]
        public void GivenTheUserClicksOnTheCartIcon()
        {
            _productosCarritoPage.HacerClicCarritoCompra();
        }

        // End Background

        [When(@"The user removes a product from the cart")]
        public void WhenTheUserRemovesProductsFromTheShoppingCart()
        {
            bool assert_eliminar_productos = _productosCarritoPage.Assert_VerificarProductosEliminadoCarrito(_productosCarritoPage.GetProductosSeleccionados());
 
            _productosCarritoPage.EjecutarCapturaEvidenciaEliminarProducto(_driver);

        }
        [Then(@"The user verifies that the selected products have been removed from the cart")]
        public void ThenTheUserVerifiesThatTheSelectedProductsHaveBeenRemovedFromTheCart()
        {
            bool empty_cart = _productosCarritoPage.IsCartEmpty();
            Assert.That(empty_cart, Is.True, "The error occurs because the products were not removed from the cart, please check the cart contents to find the difference");
        }




    }
}
