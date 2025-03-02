using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {
        #region Props
        // v

        private readonly LibraryContext _context;

        // ^
        #endregion Props

        #region Ctor
        // v

        public BorrowerRepository(LibraryContext context)
        {
            _context = context;
        }

        // ^
        #endregion Ctor

        #region Methods
        // v
        public async Task<IEnumerable<Borrower>> GetAllAsync()
        {
            return await _context.Borrowers.ToListAsync()
               ?? throw new KeyNotFoundException("No Borrower Found");
        }

        public async Task<Borrower> GetByIdAsync(int id)
        {
            return await _context.Borrowers.FindAsync(id)
               ?? throw new KeyNotFoundException("No Borrower Found");
        }

        public async Task AddAsync(Borrower borrower)
        {
            _context.Borrowers.Add(borrower);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrower borrower)
        {
            _context.Borrowers.Update(borrower);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);
            if (borrower != null)
            {
                _context.Borrowers.Remove(borrower);
                await _context.SaveChangesAsync();
            }
        }

        // ^
        #endregion Methods
    }
}
