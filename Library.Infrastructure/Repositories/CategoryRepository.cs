using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Props
        // v

        private readonly LibraryContext _context;

        // ^
        #endregion

        #region Ctor
        // v

        public CategoryRepository(LibraryContext context)
        {
            _context = context;
        }

        // ^
        #endregion Ctor

        #region Methods
        // v
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        // ^
        #endregion Methods
    }
}
