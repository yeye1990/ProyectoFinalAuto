using Newtonsoft.Json;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.JsonReader
{
    public static class JsonReaderBase
    {
        public static IEnumerable<T> GetTestData<T>(string filePath)
        {
            var jsonText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonText) ?? new List<T>();
        }
    }
}
