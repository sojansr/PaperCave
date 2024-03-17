namespace PaperCave.Core.Models.Inventory
{
    public class Book
    {
        public string Title {get; set;} = string.Empty;
        public string Author {get; set;} = string.Empty; 
        public string Publisher {get;set;} = string.Empty;
        public string Genre {get;set;} = string.Empty;
        public int Pages {get;set;}
        public int Price {get;set;}
        public DateTime PublishingDate {get;set;}
    }
}