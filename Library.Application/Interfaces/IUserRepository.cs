using Library.Core.Entities;

namespace Library.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();  // برای دریافت تمامی کاربران
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);  // برای گرفتن کاربر بر اساس آیدی
        Task AddAsync(User user);          // برای افزودن کاربر جدید
        Task UpdateAsync(User user);       // برای به‌روزرسانی اطلاعات کاربر
        Task DeleteAsync(int id);          // برای حذف کاربر بر اساس آیدی
    }
}
