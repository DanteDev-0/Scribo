

namespace Scribo.Core.Dtos
{
    public record LectureRecordDto
    {
        public int Id { get; init; }
        public string CourseName { get; init; } = string.Empty;
        public string Subject { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public string FormattedNotes { get; init; } = string.Empty;

    }
}
