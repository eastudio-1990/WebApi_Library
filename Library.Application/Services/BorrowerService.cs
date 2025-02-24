using Library.Application.Interfaces;
using Library.Core.Entities;

namespace Library.Application.Services
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerService(IBorrowerRepository borrowerRepository)
        {
            _borrowerRepository = borrowerRepository;
        }

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
    }
}
