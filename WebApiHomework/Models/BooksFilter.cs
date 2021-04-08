namespace WebApiHomework.Models
{
    /// <summary>
    /// Property types can be modified as you'd like, but the cannot be removed.
    /// </summary>
    public class BooksFilter
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public int PublishedYear { get; set; }

        public int RecommendedAge { get; set; }
    }
}
