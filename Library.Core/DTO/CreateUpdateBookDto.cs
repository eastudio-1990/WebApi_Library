namespace Library.Core.DTO
{
    public class CreateUpdateBookDto
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
        public string ISBN { get; set; }
    }
}
