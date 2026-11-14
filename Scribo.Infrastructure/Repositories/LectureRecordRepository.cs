using Scribo.Core.Interfaces;
using Scribo.Core.Models;

namespace Scribo.Infrastructure.Repositories
{
    public class LectureRecordRepository(RepositoryContext context) : RepositoryBase<LectureRecord>(context), ILectureRecordRepository
    {
        public void CreateLectureRecord(LectureRecord record) => Create(record);

        public IQueryable<LectureRecord> GetLectureRecordsByCourseName(string courseName, bool trackChanges) =>
            FindByCondition(l=> l.CourseName == courseName,trackChanges);
        
        public LectureRecord? GetSingleLectureRecord(int id, bool trackChanges) =>
            FindByCondition(l => l.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
