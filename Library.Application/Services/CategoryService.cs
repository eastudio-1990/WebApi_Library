using Library.Application.Interfaces;
using Library.Core.Entities;
using Library.Core.Interfaces;

namespace Library.Application.Services
{
    public class CategoryService : ICategoryService
    {
        #region DI
        // v

        private readonly ICategoryRepository _categoryRepository;

        // ^
        #endregion DI

        #region Ctor
        // v

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // ^
        #endregion

        #region Methods
        // v

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        // ^
        #endregion Methods
    }
}

