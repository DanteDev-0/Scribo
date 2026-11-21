using Microsoft.AspNetCore.Mvc;
using Scribo.Core.Dtos;
using Scribo.Core.Interfaces;

namespace Scribo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IServiceManager _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetLecturesByCourse([FromQuery] string courseName,[FromQuery] DateTime? date)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                return BadRequest("Ders adı zorunludur.");

            var records = await _serviceManager.LectureService
                .GetAllLectureRecordsByCourseNameAsync(courseName, date, trackChanges: false);

            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLectureRecord([FromForm] LectureRecordForCreationDto recordDto)
        {
            if (recordDto is null || recordDto.AudioFile is null || recordDto.AudioFile.Length == 0)
                return BadRequest("Geçerli bir ses dosyası yüklemelisiniz.");

            var createdRecord = await _serviceManager.LectureService.CreateLectureRecordAsync(recordDto);
            return StatusCode(201, createdRecord);
        }
    }
}
