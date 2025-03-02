using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// نویسنده
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// زمان انتشار
        /// </summary>
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// کد شابک کتاب
        /// </summary>
        [MaxLength(13)]
        public string ISBN { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
