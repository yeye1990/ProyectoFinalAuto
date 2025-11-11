using ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Models;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services;
using Moq;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Driver;


namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUnitTest
{
    public class OrderCalculatorTest : DriverBaseUnitTest
    {

        /// <summary>
        /// Verifica que el método <see cref="OrderCalculator.CalculateTotal(Order)"/> 
        /// lance una excepción cuando el carrito de compras está vacío.
        /// </summary>
        [Test]
        public void Test_ValidarErrorCarritoVacio()
        {
            // Arrange: se crea un pedido sin productos
            var order = new Order();

            // Act & Assert: se espera que lance una excepción del tipo ArgumentException
            Assert.Throws<ArgumentException>(() => _calculator.CalculateTotal(order));
        }


        /// <summary>
        /// Verifica que se aplique un descuento cuando el pedido contiene más de cinco productos.
        /// </summary>
        [Test]
        public void Test_ValidarDescuentoDespues5Productos()
        {
            // Arrange: se crean 6 productos de 10 unidades monetarias cada uno
            var order = new Order
            {
                Productos = Enumerable.Range(1, 6).Select(i => new Productos { Nombre = $"Prod{i}", Precio = 10 }).ToList()
            };

            // Act: se calcula el total con descuento aplicado
            var total = _calculator.CalculateTotal(order);

            // Assert: el total esperado es 54 (10*6=60, descuento del 10% → 54)
            Assert.That(total, Is.EqualTo(54).Within(0.01));

        }


        /// <summary>
        /// Verifica que el proceso de pago se ejecute correctamente y se envíe una notificación al finalizar.
        /// </summary>
        [Test]
        public void Test_ValidarLlamadoInterface_IPayment_INotification_CompraExitosa()
        {
            // Arrange: pedido con un solo producto
            var order = new Order
            {
                Productos = new List<Productos> { new Productos { Nombre = "Item", Precio = 100 } }
            };

            // Se configura el mock del servicio de pago para que devuelva éxito
            _paymentServiceMock.Setup(p => p.ProcessPayment(100)).Returns(true);

            // Act: se ejecuta el método de pago
            var result = _calculator.Checkout(order);

            // Assert:
            // 1. El resultado del checkout debe ser exitoso (true)
            Assert.That(result, Is.True);

            // 2. Debe haberse llamado al método Notify exactamente una vez
            _notificationServiceMock.Verify(n => n.Notify(It.IsAny<string>()), Times.Once);
        }
    }
}
