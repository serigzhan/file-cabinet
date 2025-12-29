using FileCabinetApp.Core.Entities;
using FileCabinetApp.Core.Interfaces;
using System.Text.Json;

namespace FileCabinetApp.Infrastructures.Repositories
{
    public class FileDocumentRepository : IDocumentRepository
    {

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public IEnumerable<DocumentCard> FindByNumber(string number)
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(basePath, "Infrastructures", "Data");

            if (!Directory.Exists(dataFolder))
            {
                Console.WriteLine($"Error: Data directory not found at {dataFolder}");
                yield break;
            }

            var files = Directory.GetFiles(dataFolder, $"*_#{number}.json");

            foreach (var fullPath in files)
            {
                string filename = Path.GetFileName(fullPath);

                string[] parts = filename.Split('_');
                string typePrefix = parts[0].ToLower();

                string json = File.ReadAllText(fullPath);

                DocumentCard result = null;

                if (typePrefix == "book")
                {
                    result = JsonSerializer.Deserialize<Book>(json, _options);
                }
                else if (typePrefix == "patent")
                {
                    result = JsonSerializer.Deserialize<Patent>(json, _options);
                }
                else if (typePrefix == "localizedbook")
                {
                    result = JsonSerializer.Deserialize<LocalizedBook>(json, _options);
                }

                if (result != null)
                {
                    yield return result;
                }

            }

        }

    }
}
