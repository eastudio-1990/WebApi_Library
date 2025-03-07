﻿using Library.Application.Interfaces;
using Library.Core.DTO;
using Library.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/borrowers")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BorrowersController : ControllerBase
    {
        private readonly IBorrowerService _borrowerService;

        public BorrowersController(IBorrowerService borrowerService)
        {
            _borrowerService = borrowerService;
        }

        // GET /api/borrowers
        [HttpGet]
        public async Task<IActionResult> GetBorrowers()
        {
            var borrowers = await _borrowerService.GetAllAsync();
            return Ok(borrowers);
        }

        // GET /api/borrowers/{id}
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

        // POST /api/borrowers
        [HttpPost]
        public async Task<IActionResult> AddBorrower([FromBody] CreateUpdateBorrowerDto _borrower)
        {
            if (_borrower is null)
            {
                return BadRequest();
            }

            var borrower = new Borrower
            {
                Email = _borrower.Email,
                Id = _borrower.Id,
                Name = _borrower.Name,
                Phone = _borrower.Phone,
            };

            await _borrowerService.AddAsync(borrower);
            return CreatedAtAction(nameof(GetBorrower), new { id = borrower.Id }, borrower);
        }

        // PUT /api/borrowers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBorrower(int id, [FromBody] CreateUpdateBorrowerDto _borrower)
        {
            if (id != _borrower.Id)
            {
                return BadRequest();
            }

            var borrower = new Borrower
            {
                Email = _borrower.Email,
                Id = _borrower.Id,
                Name = _borrower.Name,
                Phone = _borrower.Phone,
            };

            await _borrowerService.UpdateAsync(borrower);
            return NoContent();
        }

        // DELETE /api/borrowers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrower(int id)
        {
            if (id is 0)
            {
                return BadRequest();
            }

            await _borrowerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
