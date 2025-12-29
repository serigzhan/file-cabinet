using FileCabinetApp.Core.Interfaces;

namespace FileCabinetApp.UI
{
    public class SearchScreen
    {

        private IDocumentRepository _documentRepository;

        public SearchScreen(IDocumentRepository documentRepository)
        {

            _documentRepository = documentRepository;

        }

        public void Search()
        {
            
            while (true)
            {
                Console.Write("Enter document number: ");

                string number = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(number))
                {

                    Console.WriteLine("Number cannot be empty.");
                    return;

                }

                var documents = _documentRepository.FindByNumber(number);

                if (documents.Count() == 0)
                {
                    Console.WriteLine("Could not find any document. Try one more time.");
                    continue;
                }

                foreach (var doc in documents)
                {
                    Console.WriteLine(doc);
                }

                break;
            }

        }

    }
}
