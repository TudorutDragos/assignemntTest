using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHomework.DataAccessLayer.Models
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(100)]
        public string Genre { get; set; }

        [MaxLength(75)]
        public string Language { get; set; }

        public int PublishedYear { get; set; }

        public int NumberOfPages { get; set; }

        public bool IsHardBook { get; set; } // E-book vs HardBook

        public int RecommendedAge { get; set; }

        public int StockNumber { get; set; }
    }
}
