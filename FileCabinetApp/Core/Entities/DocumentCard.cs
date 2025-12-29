namespace FileCabinetApp.Core.Entities
{
    public abstract class DocumentCard
    {

        public string Title { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return $"[{Type}] {Title}";
        }

    }
}
