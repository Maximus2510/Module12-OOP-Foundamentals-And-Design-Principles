using System;

namespace Module12_OOP_Fundamentals_and_Design_Principles
{
    public class PatentCard : DocumentCard
    {
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UniqueId { get; set; }
    }

    public class BookCard : DocumentCard
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public DateTime DatePublished { get; set; }
    }

    public class LocalizedBookCard : BookCard
    {
        public string OriginalPublisher { get; set; }
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }
    }
}
