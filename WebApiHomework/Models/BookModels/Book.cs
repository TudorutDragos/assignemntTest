namespace WebApiHomework.Models
{
    public class Book
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public int PublishedYear { get; set; }

        public int NumberOfPages { get; set; }

        public bool IsHardBook { get; set; } // E-book vs HardBook

        public int RecommendedAge { get; set; }

        public bool ChildAppropriate { get; set; }
    }
}
