using System;
namespace Continents
{
    public class Article
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }

        public override string ToString() 
        {
            return Title + "\n" + Date;
        }
    }
}
