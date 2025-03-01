using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;

namespace Library.Application.Services
{
    public class BorrowerService : IBorrowerService
    {
        #region DI
        // v

        private readonly IBorrowerRepository _borrowerRepository;

        // ^
        #endregion DI

        #region Ctor
        // v

        public BorrowerService(IBorrowerRepository borrowerRepository)
        {
            _borrowerRepository = borrowerRepository;
        }

        // ^
        #endregion Ctor

        #region Methods
        // v

        public async Task<IEnumerable<Borrower>> GetAllAsync()
        {
            return await _borrowerRepository.GetAllAsync();
        }

        public async Task<Borrower> GetByIdAsync(int id)
        {
            return await _borrowerRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Borrower borrower)
        {
            await _borrowerRepository.AddAsync(borrower);
        }

        public async Task UpdateAsync(Borrower borrower)
        {
            await _borrowerRepository.UpdateAsync(borrower);
        }

        public async Task DeleteAsync(int id)
        {
            await _borrowerRepository.DeleteAsync(id);
        }

        // ^
        #endregion Methods
    }
}
