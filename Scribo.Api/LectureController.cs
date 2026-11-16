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

        [HttpGet("{courseName}")]
        public IActionResult GetFormattedNotesByCourseName(string courseName)
        {
            var formattedNotes = _serviceManager.LectureService.GetSingleLectureRecordByCourseName(courseName, false);
            return Ok(formattedNotes);
        }

        [HttpPost]
        public IActionResult CreateLectureRecord([FromForm] LectureRecordForCreationDto recordDto)
        {
            
            if (recordDto is null)
                return BadRequest("Kayit bos olamaz");
            
            if (recordDto.AudioFile == null || recordDto.AudioFile.Length == 0)
                return BadRequest("Gecerli bir ses dosyasi degil");
            
            var createdRecord = _serviceManager.LectureService.CreateLectureRecord(recordDto);

            return StatusCode(201, createdRecord);
        }
    }
}
