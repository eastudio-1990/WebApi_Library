using Library.Application.Interfaces;
using Library.Core.Entities;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookService _bookRepository;

        public BookService(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }



        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();

        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
