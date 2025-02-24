using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET /api/categories
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET /api/categories/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST /api/categories
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category data is required.");
            }
            await _categoryService.AddAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // POST /api/categories/{id}/child
        [HttpPost("{id}/child")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSubcategory(int id, [FromBody] Category subcategory)
        {
            if (subcategory == null)
            {
                return BadRequest("Subcategory data is required.");
            }
            var parentCategory = await _categoryService.GetByIdAsync(id);
            if (parentCategory == null)
            {
                return NotFound("Parent category not found.");
            }

            subcategory.ParentCategoryId = id;
            await _categoryService.AddAsync(subcategory);
            return CreatedAtAction(nameof(GetCategory), new { id = subcategory.Id }, subcategory);
        }

        // PUT /api/categories/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            await _categoryService.UpdateAsync(category);
            return NoContent();
        }

        // DELETE /api/categories/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
