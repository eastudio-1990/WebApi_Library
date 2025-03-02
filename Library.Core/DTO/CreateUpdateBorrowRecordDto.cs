using Library.Core.Entities;

namespace Library.Core.DTO
{
    public class CreateUpdateBorrowRecordDto
    {
        public int Id { get; set; }

        /// <summary>
        /// تاریخ امانت رفتن کتاب
        /// </summary>
        public DateTime BorrowDate { get; set; }

        /// <summary>
        /// تاریخ مرجوع کتاب امانت گرفته شده
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
    }
}
