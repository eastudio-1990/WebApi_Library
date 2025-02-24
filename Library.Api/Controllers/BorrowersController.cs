using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/borrowers")]
    [ApiController]
    public class BorrowersController : ControllerBase
    {
        private readonly IBorrowerService _borrowerService;

        public BorrowersController(IBorrowerService borrowerService)
        {
            _borrowerService = borrowerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBorrowers()
        {
            var borrowers = await _borrowerService.GetAllAsync();
            return Ok(borrowers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBorrower(int id)
        {
            var borrower = await _borrowerService.GetByIdAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }
            return Ok(borrower);
        }

        [HttpPost]
        public async Task<IActionResult> AddBorrower([FromBody] Borrower borrower)
        {
            await _borrowerService.AddAsync(borrower);
            return CreatedAtAction(nameof(GetBorrower), new { id = borrower.Id }, borrower);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBorrower(int id, [FromBody] Borrower borrower)
        {
            if (id != borrower.Id)
            {
                return BadRequest();
            }

            await _borrowerService.UpdateAsync(borrower);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrower(int id)
        {
            await _borrowerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
