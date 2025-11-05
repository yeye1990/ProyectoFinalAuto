using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceCore.Models
{
    public class Productos
    {
        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        /// <example>"Leche Entera 1L"</example>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el precio del producto.
        /// </summary>
        /// <remarks>
        /// El precio se expresa en moneda local y debe ser un valor positivo.
        /// </remarks>
        public decimal Precio { get; set; }
    }
}
