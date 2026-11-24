using Scribo.Core.Models;

namespace Scribo.Core.Interfaces
{
    public interface ILectureRecordRepository : IReadRepository<LectureRecord>, ICreateRepository<LectureRecord>
    {
        Task<LectureRecord?> GetSingleLectureRecordAsync(int id, bool trackChanges);
        Task<IEnumerable<LectureRecord>> GetLectureRecordsByCourseAsync(string courseName, DateTime? date, bool trackChanges);
    }
}
