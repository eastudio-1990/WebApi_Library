using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region Props
        // v
        private readonly LibraryContext _context;

        // ^
        #endregion

        #region Ctor

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        #endregion Ctor

        #region Methods
        // v

        // دریافت همه کتاب‌ها
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync()
                ?? throw new NullReferenceException("No Book Here");
        }

        // دریافت کتاب بر اساس ID
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id)
                 ?? throw new KeyNotFoundException($"Not Found");
        }

        // اضافه کردن کتاب
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        // بروزرسانی کتاب
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        // حذف کتاب
        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new KeyNotFoundException("Book Not Found");
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        // ^
        #endregion Methods
    }
}