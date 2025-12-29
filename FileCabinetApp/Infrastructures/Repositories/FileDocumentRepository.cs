using FileCabinetApp.Core.Entities;
using FileCabinetApp.Core.Interfaces;

namespace FileCabinetApp.Infrastructures.Repositories
{
    public class FileDocumentRepository : IDocumentRepository
    {

        public IEnumerable<DocumentCard> FindByNumber(string number)
        {
            throw new NotImplementedException();
        }

    }
}
