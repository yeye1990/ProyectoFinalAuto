using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceProductosCarrito.Data;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceProductosCarrito
{
    public class ECommerceProductosCarritoFormTest : DriverBase
    {
        /// <summary>
        /// Caso de prueba que valida la adición de productos al carrito de compras en la aplicación E-Commerce.
        /// Usa los datos provenientes de un archivo JSON a través de la clase DataAgregarProductosCarrito.
        /// </summary>
        /// <param name="usuario">Nombre de usuario válido para iniciar sesión en el sistema.</param>
        /// <param name="contrasena">Contraseña asociada al usuario.</param>
        /// <param name="lproductos">Lista de identificadores de productos que se desean agregar al carrito.</param>
        /// <param name="evidencia">Nombre o ruta para capturar evidencia de la acción realizada.</param>
        [TestCaseSource(typeof(DataAgregarProductosCarrito), nameof(DataAgregarProductosCarrito.GetJsonDataAgregarProductos))]
        public void Test_ProductosCarrito(string usuario, string contrasena, List<int> lproductos, string evidencia)
        {
            //Arrange
            var loginpage = new ECommerceLoginPage(Driver);
            var productosCarritoPage = new ECommerceProductosCarritoPage(Driver);

            //Act
            loginpage.IngresarCredenciales(usuario,contrasena);
            productosCarritoPage.EjecutarCapturaEvidencia(Driver);
            loginpage.HacerClicBoton();
            productosCarritoPage.AgregarProductosCarrito(lproductos, evidencia);
            productosCarritoPage.HacerClicCarritoCompra();
            productosCarritoPage.EjecutarCapturaEvidencia(Driver);
            bool assert_productos_carrito = productosCarritoPage.Assert_VerificarProductosCarrito(productosCarritoPage.GetProductosSeleccionados());

            //Assert
            Assert.That(assert_productos_carrito, Is.True,$"El error se presenta porque los productos verificados no coinciden con los seleccionados para la prueba, por favor examina la lista de productos: {string.Join(", ",productosCarritoPage.GetProductosSeleccionados())}"+", y así podrás encontrar la diferencia");

        }


        /// <summary>
        /// Caso de prueba que valida la eliminación de productos del carrito de compras en la aplicación E-Commerce.
        /// Usa los datos provenientes de un archivo JSON a través de la clase DataEliminarProductosCarrito.
        /// El test inicia sesión, agrega productos al carrito, navega al carrito y verifica que los productos
        /// seleccionados sean removidos correctamente.
        /// </summary>
        /// <param name="usuario">Nombre de usuario válido para iniciar sesión en el sistema.</param>
        /// <param name="contrasena">Contraseña asociada al usuario.</param>
        /// <param name="lproductos">Lista de identificadores de productos que se desean agregar y posteriormente eliminar del carrito.</param>
        [TestCaseSource(typeof(DataEliminarProductosCarrito), nameof(DataEliminarProductosCarrito.GetJsonDataEliminarProductos))]
        public void Test_EliminarProductosCarrito(string usuario, string contrasena, List<int> lproductos) 
        {
            //Arrange
            var loginpage = new ECommerceLoginPage(Driver);
            var productosCarritoPage = new ECommerceProductosCarritoPage(Driver);

            //Act
            loginpage.IngresarCredenciales("standard_user", "secret_sauce");
            productosCarritoPage.EjecutarCapturaEvidenciaEliminarProducto(Driver);
            loginpage.HacerClicBoton();
            productosCarritoPage.EjecutarCapturaEvidenciaEliminarProducto(Driver);
            productosCarritoPage.AgregarProductosCarrito(new List<int> { 1, 2, 3 },"Productos");
            productosCarritoPage.HacerClicCarritoCompra();
            bool assert_eliminar_productos = productosCarritoPage.Assert_VerificarProductosEliminadoCarrito(productosCarritoPage.GetProductosSeleccionados());
            productosCarritoPage.RegresarPaginaPrincipal();
            productosCarritoPage.EjecutarCapturaEvidenciaEliminarProducto(Driver);

            //Assert
            Assert.That(assert_eliminar_productos, Is.True, "El error se presenta porque los productos no fueron eliminados correctamente del carrito de compras.");
        }

    }
}
