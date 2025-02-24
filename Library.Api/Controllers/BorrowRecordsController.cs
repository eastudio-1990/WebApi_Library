using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/borrowRecords")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BorrowRecordsController : ControllerBase
    {
        private readonly IBorrowRecordService _borrowRecordService;

        public BorrowRecordsController(IBorrowRecordService borrowRecordService)
        {
            _borrowRecordService = borrowRecordService;
        }

        // GET /api/borrowrecords
        [HttpGet]
        public async Task<IActionResult> GetBorrowRecords()
        {
            var borrowRecords = await _borrowRecordService.GetAllAsync();
            return Ok(borrowRecords);
        }

        // GET /api/borrowrecords/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBorrowRecord(int id)
        {
            var borrowRecord = await _borrowRecordService.GetByIdAsync(id);
            if (borrowRecord == null)
            {
                return NotFound();
            }
            return Ok(borrowRecord);
        }

        // POST /api/borrowrecords
        [HttpPost]
        public async Task<IActionResult> AddBorrowRecord([FromBody] BorrowRecord borrowRecord)
        {
            await _borrowRecordService.AddAsync(borrowRecord);
            return CreatedAtAction(nameof(GetBorrowRecord), new { id = borrowRecord.Id }, borrowRecord);
        }

        // PUT /api/borrowrecords/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBorrowRecord(int id, [FromBody] BorrowRecord borrowRecord)
        {
            if (id != borrowRecord.Id)
            {
                return BadRequest();
            }

            await _borrowRecordService.UpdateAsync(borrowRecord);
            return NoContent();
        }

        // DELETE /api/borrowrecords/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowRecord(int id)
        {
            await _borrowRecordService.DeleteAsync(id);
            return NoContent();
        }
    }
}
