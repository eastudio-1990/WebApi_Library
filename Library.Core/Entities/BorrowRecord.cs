namespace Library.Core.Entities
{
    public class BorrowRecord
    {
        public int Id { get; set; }

        /// <summary>
        /// تاریخ امانت گرفتن کتاب
        /// </summary>
        public DateTime BorrowDate { get; set; }

        /// <summary>
        /// تاریخ بازگشت کتاب
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
    }
}
