using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Procesa un pago por el monto especificado.
        /// </summary>
        /// <param name="amount">Monto total a pagar.</param>
        /// <returns>
        /// <c>true</c> si el pago fue procesado exitosamente; de lo contrario, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// La implementación concreta de esta interfaz puede conectarse con distintos
        /// proveedores de pago (por ejemplo, tarjeta, transferencia o billetera digital).
        /// </remarks>
        bool ProcessPayment(decimal amount);
    }
}
