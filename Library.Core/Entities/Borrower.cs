using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class Borrower
    {
        public int Id { get; set; }

        /// <summary>
        /// نام امانت گیرنده کتاب
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ایمیل امانت گیرنده
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// همراه امانت گیرنده کتاب
        /// </summary>
        [MaxLength(15)]
        public string Phone { get; set; }

        /// <summary>
        /// لیست کتاب‌های امانت گرفته‌شده
        /// </summary>
        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new HashSet<BorrowRecord>();
    }
}
