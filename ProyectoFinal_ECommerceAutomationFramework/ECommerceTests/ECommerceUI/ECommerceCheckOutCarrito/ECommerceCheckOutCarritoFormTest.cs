using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceCheckOutCarrito;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceLogin;
using ProyectoFinal_ECommerceAutomationFramework.ECommercePages.ECommerceProductosCarrito;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceCheckOutCarrito.Data;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceCheckOutCarrito
{
    public class ECommerceCheckOutCarritoFormTest : DriverBase
    {
        /// <summary>
        /// Caso de prueba que valida el flujo completo de compra en el carrito de compras (CheckOut) de forma exitosa.
        /// Se basa en datos externos (JSON) que definen las credenciales, productos seleccionados y valores esperados en cada paso.
        /// </summary>
        /// <param name="pusuario">Usuario válido que inicia sesión en el sistema.</param>
        /// <param name="pcontrasenna">Contraseña del usuario.</param>
        /// <param name="lproductos">Lista de índices de los productos que se deben agregar al carrito.</param>
        /// <param name="pnombre">Nombre del cliente utilizado en el formulario de Checkout.</param>
        /// <param name="papellido">Apellido del cliente utilizado en el formulario de Checkout.</param>
        /// <param name="pcodigoPostal">Código postal ingresado durante el proceso de Checkout.</param>
        /// <param name="p_assert_titulo_datos_cliente">Título esperado en la pantalla de datos del cliente.</param>
        /// <param name="p_assert_titulo_desglose_compra">Título esperado en la pantalla de desglose o resumen de compra.</param>
        /// <param name="p_assert_monto_total_productos">Monto esperado de la suma de los productos seleccionados.</param>
        /// <param name="p_assert_monto_total_compra">Monto total esperado de la compra (productos + impuestos).</param>
        /// <param name="p_assert_mensaje_compra_exitosa">Mensaje esperado tras completar exitosamente la compra.</param>
        [TestCaseSource(typeof(DataCheckOutCarritoExitoso), nameof(DataCheckOutCarritoExitoso.GetJsonDataCheckOut))]
        [Ignore("Temporalmente deshabilitado para la evaluación de SpecFlow + Gherkin")]
        public void Test_CheckOutCarrito(string pusuario, string pcontrasenna, List<int> lproductos, string pnombre, string papellido, string pcodigoPostal, string p_assert_titulo_datos_cliente, string p_assert_titulo_desglose_compra, string p_assert_monto_total_productos, string p_assert_monto_total_compra, string p_assert_mensaje_compra_exitosa, string evidencia)
        {
            //Arrange
            var loginpage = new ECommerceLoginPage(Driver!);
            var productosCarritoPage = new ECommerceProductosCarritoPage(Driver!);
            var checkOutCarritoPage = new ECommerceCheckOutCarritoPage(Driver!);
            //Act
            loginpage.IngresarCredenciales(pusuario, pcontrasenna);
            checkOutCarritoPage.EjecutarCapturaEvidencia(Driver!);
            loginpage.HacerClicBoton();
            checkOutCarritoPage.EjecutarCapturaEvidencia(Driver!);
            productosCarritoPage.AgregarProductosCarrito(lproductos, evidencia);
            productosCarritoPage.HacerClicCarritoCompra();
            checkOutCarritoPage.EjecutarCapturaEvidencia(Driver!);
            checkOutCarritoPage.HacerClicBtnCheckout();
            string assert_titulo_datos_cliente = checkOutCarritoPage.Assert_TituloDatosClienteCheckOut();
            checkOutCarritoPage.IngresarDatosCliente(pnombre, papellido, pcodigoPostal);
            checkOutCarritoPage.EjecutarCapturaEvidencia(Driver!);
            checkOutCarritoPage.HacerClicBtnContinuar();
            string assert_titulo_desglose_compra = checkOutCarritoPage.Assert_TituloDesgloseCompraCheckOut();
            string assert_monto_total_productos = checkOutCarritoPage.Assert_VerificarTotalSumaProductos(productosCarritoPage.GetProductosSeleccionados());
            string assert_monto_total_compra = checkOutCarritoPage.Assert_VerificarMontoTotalCompra(productosCarritoPage.GetProductosSeleccionados());
            checkOutCarritoPage.EjecutarCapturaEvidencia(Driver!);
            checkOutCarritoPage.HacerClicBtnFinalizarCompra();
            checkOutCarritoPage.EjecutarCapturaEvidencia(Driver!);
            string assert_mensaje_compra_exitosa = checkOutCarritoPage.Assert_MensajeConfirmacionCompraCheckOut();


            //Assert
            Assert.That(assert_titulo_datos_cliente, Is.EqualTo(p_assert_titulo_datos_cliente));
            Assert.That(assert_titulo_desglose_compra, Is.EqualTo(p_assert_titulo_desglose_compra));
            Assert.That(assert_monto_total_productos, Is.EqualTo(p_assert_monto_total_productos));
            Assert.That(assert_monto_total_compra, Is.EqualTo(p_assert_monto_total_compra));
            Assert.That(assert_mensaje_compra_exitosa, Is.EqualTo(p_assert_mensaje_compra_exitosa));
        }
    }
}
