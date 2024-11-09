using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDataDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = @"C:\Users\ertan\source\repos\JsonDataDictionary\resources";

            // Klasör altındaki tüm .ts dosyalarını bul
            var tsFiles = Directory.GetFiles(basePath, "*.ts", SearchOption.AllDirectories);
            tsFiles = Array.FindAll(tsFiles, file => !Path.GetFileName(file).Equals("index.ts", StringComparison.OrdinalIgnoreCase));

            foreach (var filePath in tsFiles)
            {
                Console.WriteLine($"Dosya: {Path.GetFileName(filePath)}");

                try
                {
                    string tsContent = File.ReadAllText(filePath);

                    // Sadece JSON kısmını çekmek için "export default" kısmını kaldır ve kalan içeriği JSON olarak işle
                    string jsonContent = ExtractJsonContent(tsContent);
                    var resourceData = JsonConvert.DeserializeObject<JObject>(jsonContent);

                    foreach (var rootProperty in resourceData.Properties())
                    {
                        string rootKey = rootProperty.Name;
                        PrintResourceData(rootProperty.Value as JObject, rootKey);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }

                Console.WriteLine(new string('-', 50));
            }
        }

        static string ExtractJsonContent(string tsContent)
        {
            // "export default" satırını kaldır
            int startIndex = tsContent.IndexOf("{");
            int endIndex = tsContent.LastIndexOf("}");

            if (startIndex >= 0 && endIndex > startIndex)
            {
                return tsContent.Substring(startIndex, endIndex - startIndex + 1);
            }

            throw new Exception("JSON içeriği çıkarılamadı.");
        }

        static void PrintResourceData(JObject data, string parentKey)
        {
            foreach (var property in data.Properties())
            {
                string key = property.Name;
                var value = property.Value;

                if (value is JObject nestedObject)
                {
                    PrintResourceData(nestedObject, $"{parentKey}.{key}");
                }
                else
                {
                    Console.WriteLine($"{parentKey}.{key} => {value}");
                }
            }
        }
    }
}
