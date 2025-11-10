using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Models
{
    public class Order
    {
        /// <summary>
        /// Obtiene o establece la lista de productos incluidos en el pedido.
        /// </summary>
        /// <remarks>
        /// Se inicializa por defecto como una lista vacía para evitar valores nulos.
        /// Cada elemento de la lista es un objeto de tipo <see cref="Productos"/>.
        /// </remarks>
        public List<Productos> Productos { get; set; } = new();

    }
}
