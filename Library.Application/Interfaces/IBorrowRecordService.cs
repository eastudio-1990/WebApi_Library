using Library.Core.Entities;

namespace Library.Application.Interfaces
{
    public interface IBorrowRecordService
    {
        Task<IEnumerable<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord> GetByIdAsync(int id);
        Task AddAsync(BorrowRecord borrowRecord);
        Task UpdateAsync(BorrowRecord borrowRecord);
        Task DeleteAsync(int id);
    }
}
