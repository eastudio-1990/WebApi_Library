using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/borrowRecords")]
    [ApiController]
    public class BorrowRecordsController : ControllerBase
    {
        private readonly IBorrowRecordService _borrowRecordService;

        public BorrowRecordsController(IBorrowRecordService borrowRecordService)
        {
            _borrowRecordService = borrowRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBorrowRecords()
        {
            var borrowRecords = await _borrowRecordService.GetAllAsync();
            return Ok(borrowRecords);
        }

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

        [HttpPost]
        public async Task<IActionResult> AddBorrowRecord([FromBody] BorrowRecord borrowRecord)
        {
            await _borrowRecordService.AddAsync(borrowRecord);
            return CreatedAtAction(nameof(GetBorrowRecord), new { id = borrowRecord.Id }, borrowRecord);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowRecord(int id)
        {
            await _borrowRecordService.DeleteAsync(id);
            return NoContent();
        }
    }
}
