using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Data
{
    public class BookData
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AuthorUrl { get; set; }
        public string TitleUrl { get; set; }
        public string DescriptionUrl { get; set; }

        public DateTime TimeStampData { get; set; }
    }
}
