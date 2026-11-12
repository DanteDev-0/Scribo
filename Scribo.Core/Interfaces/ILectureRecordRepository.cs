using Scribo.Api.Models;

namespace Scribo.Core.Interfaces
{
    public interface ILectureRecordRepository : IRepositoryBase<LectureRecord>
    {
        LectureRecord GetSingleLectureRecord(int id, bool trackChanges);
        IQueryable<LectureRecord> GetLectureRecordsByCourseName(string courseName, bool trackChanges);
        void CreateLectureRecord(LectureRecord record);
    }
}
