using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;

namespace Library.Application.Services
{
    public class UserService : IUserService
    {

        #region DI
        // v

        private readonly IUserRepository _userRepository;

        // ^
        #endregion DI

        #region Ctor
        // v

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // ^
        #endregion Ctor

        #region Methods
        // v

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            // شما نیاز دارید که متد `GetByIdAsync` را در `IUserRepository` نیز پیاده‌سازی کنید.
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(User user)
        {
            // برای اضافه کردن کاربر به دیتابیس می‌توانید از یک متد مناسب در `IUserRepository` استفاده کنید.
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            // برای به‌روزرسانی کاربر
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            // برای حذف کاربر از دیتابیس
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // ^
        #endregion Methods
    }
}
