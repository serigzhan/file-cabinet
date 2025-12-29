namespace FileCabinetApp.Core.Entities
{
    public class LocalizedBook : Book
    {

        public string CountryOfLocalization { get; set; }

        public string LocalPublisher { get; set; }

        public LocalizedBook()
        {

            Type = "localizedbook";

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
