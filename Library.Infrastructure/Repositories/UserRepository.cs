using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Props
        // v

        private readonly LibraryContext _context;
        private readonly List<User> _users = new();

        // ^
        #endregion Props

        #region Ctor
        // v

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        // ^
        #endregion Ctor

        #region Methods
        // v

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        // ^
        #endregion Methods
    }
}
