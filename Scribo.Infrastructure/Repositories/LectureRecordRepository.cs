using Microsoft.EntityFrameworkCore;
using Scribo.Core.Interfaces;
using Scribo.Core.Models;

namespace Scribo.Infrastructure.Repositories
{
    public class LectureRecordRepository(RepositoryContext context) : RepositoryBase<LectureRecord>(context), ILectureRecordRepository
    {
        public void CreateLectureRecord(LectureRecord record) => Create(record);
        public async Task<IEnumerable<LectureRecord>> GetLectureRecordsByCourseAsync(string courseName, DateTime? date, bool trackChanges)
        {
            var query = FindByConditionAsync(r => r.CourseName == courseName, trackChanges);

            if (date.HasValue)
            {
                var startOfDay = date.Value.Date;
                var endOfDay = startOfDay.AddDays(1);

                query = query.Where(q => q.CreatedAt >= startOfDay && q.CreatedAt < endOfDay);
            }

            return await query.OrderByDescending(r => r.CreatedAt).ToListAsync();

                
        }
        public async Task<LectureRecord?> GetSingleLectureRecordAsync(int id, bool trackChanges) =>
           await FindByConditionAsync(l => l.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
