namespace FileCabinetApp.Core.Entities
{
    public class Patent : DocumentCard
    {

        string Id { get; set; }

        public List<string> Authors { get; set; }

        public DateTime DatePublished { get; set; }

        public DateTime ExpirationDate {  get; set; }

        public Patent()
        {

            Type = "patent";

        }

        public override string ToString()
        {
            return $"{base.ToString()} | {Id}";
        }
    }
}
