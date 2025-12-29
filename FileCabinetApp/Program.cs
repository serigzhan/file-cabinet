using FileCabinetApp.Core.Interfaces;
using FileCabinetApp.Infrastructures.Repositories;
using FileCabinetApp.UI;

IDocumentRepository fileDocumentRepository = new FileDocumentRepository();

var consoleScreen = new SearchScreen(fileDocumentRepository);

consoleScreen.Search();

Console.ReadLine();