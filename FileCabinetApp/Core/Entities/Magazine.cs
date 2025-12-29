namespace FileCabinetApp.Core.Entities
{
    public class Magazine : DocumentCard
    {

        public string Publisher { get; set; }

        public string ReleaseNumber { get; set; }

        public DateTime DatePublished { get; set; }

        public Magazine()
        {

            Type = "magazine";

        }

        public override string ToString()
        {
            return $"{base.ToString()} | {Publisher} | {ReleaseNumber}";
        }
    }
}
