using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region Props
        // v

        private readonly List<Book> _books = new();  // لیست ساده به عنوان ذخیره‌سازی موقت
        private int _nextId = 1;  // مقداردهی ID اولیه

        // ^
        #endregion

        #region Methods
        // v

        // دریافت همه کتاب‌ها
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_books);
        }

        // دریافت کتاب بر اساس ID
        public async Task<Book> GetByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(book);
        }

        // اضافه کردن کتاب
        public async Task AddAsync(Book book)
        {
            book.Id = _nextId++;  // ID جدید برای کتاب
            _books.Add(book);      // اضافه کردن کتاب به لیست
            await Task.CompletedTask;
        }

        // بروزرسانی کتاب
        public async Task UpdateAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.PublishedDate = book.PublishedDate;
            }
            await Task.CompletedTask;
        }

        // حذف کتاب
        public async Task DeleteAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            await Task.CompletedTask;
        }

        // ^
        #endregion Methods
    }
}