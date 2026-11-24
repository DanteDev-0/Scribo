using Microsoft.AspNetCore.Http;

namespace Scribo.Core.Dtos
{
    public record LectureRecordForCreationDto
    {
        public string CourseName { get; init; } = string.Empty;
        public string Subject { get; init; } = string.Empty;
        public IFormFile AudioFile { get; init; } = null!;
    }
}
