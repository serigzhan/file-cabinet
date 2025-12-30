using FileCabinetApp.Core.Interfaces;
using FileCabinetApp.Infrastructures.Repositories;
using FileCabinetApp.UI;

IDocumentRepository fileDocumentRepository = new FileDocumentRepository();

IDocumentRepository repository = new CachedDocumentRepository(fileDocumentRepository);

var consoleScreen = new SearchScreen(repository);

while (true)
{
    
    consoleScreen.Search();

    Console.WriteLine();
    Console.Write("Want to continue? [y/n] ");

    var answer = Console.ReadLine();

    if (answer.ToLower() != "y")
    {
        break;
    }

}