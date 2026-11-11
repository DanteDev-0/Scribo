namespace Scribo.Api.Models
{
    public class LectureRecord
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string FormattedNotes { get; set; } = string.Empty;
        public string? UserId { get; set; }

    }
}
