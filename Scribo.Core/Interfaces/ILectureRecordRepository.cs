using Scribo.Api.Models;

namespace Scribo.Core.Interfaces
{
    public interface ILectureRecordRepository : IReadRepository<LectureRecord>, ICreateRepository<LectureRecord>
    {
        LectureRecord? GetSingleLectureRecord(int id, bool trackChanges);
        IQueryable<LectureRecord> GetLectureRecordsByCourseName(string courseName, bool trackChanges);
    }
}
