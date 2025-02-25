using Library.Application.Interfaces;
using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        #region DI
        // v

        private readonly IBookRepository _bookRepository;

        // ^
        #endregion DI

        #region Ctor 
        // v

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // ^
        #endregion Ctor

        #region Methods 
        // v

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

        // ^
        #endregion 
    }
}
