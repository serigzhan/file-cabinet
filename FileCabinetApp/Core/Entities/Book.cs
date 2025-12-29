namespace FileCabinetApp.Core.Entities
{
    public class Book : DocumentCard
    {

        public string ISBN { get; set; }

        public List<string> Authors { get; set; }

        public string Publisher { get; set; }

        public string NumberOfPages { get; set; }

        public DateTime DatePublished { get; set; }

        public Book()
        {

            Type = "book";

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
