using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Services.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Envía una notificación con el mensaje especificado.
        /// </summary>
        /// <param name="message">Contenido del mensaje a enviar al usuario.</param>
        /// <remarks>
        /// La implementación concreta puede enviar la notificación por distintos medios,
        /// como correo electrónico, mensaje de texto o notificación en pantalla.
        /// </remarks>
        void Notify(string message);
    }
}
