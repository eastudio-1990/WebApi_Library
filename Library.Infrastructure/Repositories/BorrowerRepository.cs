using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly LibraryContext _context;

        public BorrowerRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Borrower>> GetAllAsync()
        {
            return await _context.Borrowers.ToListAsync();
        }

        public async Task<Borrower> GetByIdAsync(int id)
        {
            return await _context.Borrowers.FindAsync(id);
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
    }
}
