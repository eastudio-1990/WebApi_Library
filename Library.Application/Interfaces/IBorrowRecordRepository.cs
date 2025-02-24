using Library.Core.Entities;

namespace Library.Application.Interfaces
{
    public interface IBorrowRecordRepository
    {
        Task<IEnumerable<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord> GetByIdAsync(int id);
        Task AddAsync(BorrowRecord borrowRecord);
        Task UpdateAsync(BorrowRecord borrowRecord);
        Task DeleteAsync(int id);
    }
}
