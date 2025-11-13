using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.JsonReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceProductosCarrito.Data
{
    internal class DataEliminarProductosCarrito
    {
        public string? usuario { get; set; }
        public string? contrasena { get; set; }
        public List<int>? productosSeleccionados { get; set; }
        public string? evidencia { get; set; }

        /// <summary>
        /// Obtiene los datos de prueba para agregar productos al carrito desde un archivo JSON.
        /// Cada elemento generado contiene los parámetros necesarios para ejecutar el escenario:
        /// usuario, contraseña, lista de productos seleccionados y evidencia de la acción.
        /// </summary>
        public static IEnumerable<TestCaseData> GetJsonDataEliminarProductos()
        {
            // Construye la ruta absoluta al archivo JSON
            var filePath = Path.GetFullPath(
                Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceProductosCarrito", "Data", "EliminarProductosCarrito", "EliminarProductosCarritoData.json"
                )
            );

            // Usa la ruta construida dinámicamente
            var data = JsonReaderBase.GetTestData<DataEliminarProductosCarrito>(filePath);

            foreach (var item in data)
            {
                yield return new TestCaseData(item.usuario, item.contrasena, item.productosSeleccionados, item.evidencia);
            }
        }
    }
}
