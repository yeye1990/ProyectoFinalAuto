using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.JsonReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceTests.ECommerceUI.ECommerceLogin.Data
{
    internal class DataLoginInvalido
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string msj_error { get; set; }

        public static IEnumerable<TestCaseData> GetJsonDataLoginInvalido()
        {
            // Construye la ruta absoluta al archivo JSON
            var filePath = Path.GetFullPath(
                Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    @"..", @"..", @"..",
                    "ECommerceTests", "ECommerceUI", "ECommerceLogin", "Data", "LoginInvalido", "LoginInvalidoData.json"
                )
            );

            // Usa la ruta construida dinámicamente
            var data = JsonReaderBase.GetTestData<DataLoginInvalido>(filePath);

            foreach (var item in data)
            {
                yield return new TestCaseData(item.usuario, item.contrasena, item.msj_error);
            }
        }

    }
}
