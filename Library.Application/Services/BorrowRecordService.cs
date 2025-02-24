using Library.Application.Interfaces;
using Library.Core.Entities;

namespace Library.Application.Services
{
    public class BorrowRecordService : IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _borrowRecordRepository;

        public BorrowRecordService(IBorrowRecordRepository borrowRecordRepository)
        {
            _borrowRecordRepository = borrowRecordRepository;
        }

        public async Task<IEnumerable<BorrowRecord>> GetAllAsync()
        {
            return await _borrowRecordRepository.GetAllAsync();
        }

        public async Task<BorrowRecord> GetByIdAsync(int id)
        {
            return await _borrowRecordRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(BorrowRecord borrowRecord)
        {
            await _borrowRecordRepository.AddAsync(borrowRecord);
        }

        public async Task UpdateAsync(BorrowRecord borrowRecord)
        {
            await _borrowRecordRepository.UpdateAsync(borrowRecord);
        }

        public async Task DeleteAsync(int id)
        {
            await _borrowRecordRepository.DeleteAsync(id);
        }
    }
}
