using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.JsonReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceCheckOutCarrito.Data
{
    internal class DataCheckOutCarritoExitoso
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public List<int> productosSeleccionados { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string codigoPostal { get; set; }
        public string assert_titulo_datos_cliente { get; set; }
        public string assert_titulo_desglose_compra { get; set; }
        public string assert_monto_total_productos { get; set; }
        public string assert_monto_total_compra { get; set; }
        public string assert_mensaje_compra_exitosa { get; set; }
        public string evidencia { get; set; }


        /// <summary>
        /// Obtiene los datos de prueba para el flujo de CheckOut del carrito de compras desde un archivo JSON.
        /// Cada elemento generado contiene los parámetros necesarios para ejecutar el escenario completo de checkout:
        /// usuario, contraseña, productos seleccionados, información del cliente, títulos esperados, montos totales, mensaje de confirmación y evidencia.
        /// </summary>
        public static IEnumerable<TestCaseData> GetJsonDataCheckOut()
        {
            // Construye la ruta absoluta al archivo JSON
            var filePath = Path.GetFullPath(
                Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceCheckOutCarrito", "Data", "CheckOutCarritoExitoso", "CheckOutCarritoExitosoData.json"
                )
            );

            // Usa la ruta construida dinámicamente
            var data = JsonReaderBase.GetTestData<DataCheckOutCarritoExitoso>(filePath);

            foreach (var item in data)
            {
                yield return new TestCaseData(item.usuario, item.contrasena, item.productosSeleccionados, item.nombreCliente, item.apellidoCliente, item.codigoPostal, item.assert_titulo_datos_cliente, item.assert_titulo_desglose_compra, item.assert_monto_total_productos, item.assert_monto_total_compra, item.assert_mensaje_compra_exitosa, item.evidencia);
            }
        }
    }
}
