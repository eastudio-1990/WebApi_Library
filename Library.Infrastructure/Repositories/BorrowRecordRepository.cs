﻿using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        #region Props
        // v

        private readonly LibraryContext _context;

        // ^
        #endregion Porps

        #region Ctor
        // v

        public BorrowRecordRepository(LibraryContext context)
        {
            _context = context;
        }

        // ^
        #endregion Ctor

        #region Methods
        // v
        public async Task<IEnumerable<BorrowRecord>> GetAllAsync()
        {
            return await _context.BorrowRecords.Include(br => br.Book).Include(br => br.Borrower).ToListAsync();
        }

        public async Task<BorrowRecord> GetByIdAsync(int id)
        {
            return await _context.BorrowRecords.Include(br => br.Book).Include(br => br.Borrower).FirstOrDefaultAsync(br => br.Id == id);
        }

        public async Task AddAsync(BorrowRecord borrowRecord)
        {
            _context.BorrowRecords.Add(borrowRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BorrowRecord borrowRecord)
        {
            _context.BorrowRecords.Update(borrowRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var borrowRecord = await _context.BorrowRecords.FindAsync(id);
            if (borrowRecord != null)
            {
                _context.BorrowRecords.Remove(borrowRecord);
                await _context.SaveChangesAsync();
            }
        }

        // ^
        #endregion Methods
    }
}
