using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;

namespace Library.Application.Services
{
    public class BorrowRecordService : IBorrowRecordService
    {

        #region DI
        // v

        private readonly IBorrowRecordRepository _borrowRecordRepository;

        // ^
        #endregion DI

        #region Ctor
        // v

        public BorrowRecordService(IBorrowRecordRepository borrowRecordRepository)
        {
            _borrowRecordRepository = borrowRecordRepository;
        }

        // ^
        #endregion  Ctor

        #region Methods
        // v

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

        // ^
        #endregion Methods
    }
}
