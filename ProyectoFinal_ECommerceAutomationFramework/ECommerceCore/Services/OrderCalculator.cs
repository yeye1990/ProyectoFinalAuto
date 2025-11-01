using ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Models;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services
{
    public class OrderCalculator
    {
        // Dependencias externas inyectadas mediante el constructor
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OrderCalculator"/>.
        /// </summary>
        /// <param name="paymentService">
        /// Servicio encargado de procesar los pagos de los pedidos.
        /// </param>
        /// <param name="notificationService">
        /// Servicio encargado de enviar notificaciones al usuario después de la compra.
        /// </param>
        public OrderCalculator(IPaymentService paymentService, INotificationService notificationService)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
        }


        /// <summary>
        /// Calcula el monto total de un pedido.
        /// </summary>
        /// <param name="order">El pedido que contiene la lista de productos.</param>
        /// <returns>El total calculado del pedido.</returns>
        /// <exception cref="ArgumentException">
        /// Se lanza si el carrito está vacío o la lista de productos es nula.
        /// </exception>
        /// <remarks>
        /// Si el pedido contiene más de 5 productos, se aplica un descuento del 10%.
        /// </remarks>
        public decimal CalculateTotal(Order order)
        {
            // Validación: el carrito no debe estar vacío
            if (order.Productos == null || !order.Productos.Any())
                throw new ArgumentException("El carrito está vacío.");

            // Suma del precio de todos los productos
            decimal total = order.Productos.Sum(p => p.Precio);

            // Regla de negocio: aplicar un 10% de descuento si hay más de 5 productos
            if (order.Productos.Count > 5)
            {
                total *= 0.9m; // 10% de descuento
            }

            return total;
        }


        /// <summary>
        /// Realiza el proceso de compra (checkout) del pedido.
        /// </summary>
        /// <param name="order">El pedido que se desea procesar.</param>
        /// <returns>
        /// <c>true</c> si el pago se procesó exitosamente; de lo contrario, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Este método:
        /// <list type="number">
        /// <item>Calcula el total del pedido.</item>
        /// <item>Intenta procesar el pago usando <see cref="IPaymentService"/>.</item>
        /// <item>Si el pago es exitoso, envía una notificación usando <see cref="INotificationService"/>.</item>
        /// </list>
        /// </remarks>
        public bool Checkout(Order order)
        {
            // Calcula el total del pedido antes de pagar
            var total = CalculateTotal(order);

            // Procesa el pago usando el servicio inyectado
            bool success = _paymentService.ProcessPayment(total);

            // Si el pago fue exitoso, se notifica al usuario
            if (success)
            {
                _notificationService.Notify("Compra completada con éxito.");
            }

            return success;
        }
    }
}
