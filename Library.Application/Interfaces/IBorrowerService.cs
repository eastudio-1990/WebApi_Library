using Library.Core.Entities;

namespace Library.Application.Interfaces
{
    public interface IBorrowerService
    {
        Task<IEnumerable<Borrower>> GetAllAsync();
        Task<Borrower> GetByIdAsync(int id);
        Task AddAsync(Borrower borrower);
        Task UpdateAsync(Borrower borrower);
        Task DeleteAsync(int id);
    }
}
