using FileCabinetApp.Core.Entities;

namespace FileCabinetApp.Core.Interfaces
{
    public interface IDocumentRepository
    {

        IEnumerable<DocumentCard> FindByNumber(string number);

    }
}
