using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.JsonReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data
{
    internal class DataLoginValido
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string assert_pass { get; set; }
        public string assert_title_form_login { get; set; }

        /// <summary>
        /// Obtiene los datos de prueba para el login válido desde un archivo JSON.
        /// Cada elemento generado contiene los parámetros necesarios para probar el inicio de sesión exitoso:
        /// usuario, contraseña, mensaje esperado de confirmación de ingreso y título esperado del formulario de login.
        /// </summary>
        public static IEnumerable<TestCaseData> GetJsonDataLoginValido()
        {
            // Construye la ruta absoluta al archivo JSON
            var filePath = Path.GetFullPath(
                Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceLogin", "Data", "LoginValido", "LoginValidoData.json"
                )
            );

            // Usa la ruta construida dinámicamente
            var data = JsonReaderBase.GetTestData<DataLoginValido>(filePath);

            foreach (var item in data)
            {
                yield return new TestCaseData(item.usuario, item.contrasena, item.assert_pass, item.assert_title_form_login);
            }
        }
    }
}
