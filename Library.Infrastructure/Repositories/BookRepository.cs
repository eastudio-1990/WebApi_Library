using Library.Application.Interfaces;
using Library.Core.Entities;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookService
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_books);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(book);
        }

        public async Task AddAsync(Book book)
        {
            book.Id = _nextId++; // مقدار ID را افزایش می‌دهیم
            _books.Add(book);
            await Task.CompletedTask;
        }

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

        public async Task DeleteAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            await Task.CompletedTask;
        }

    }
}