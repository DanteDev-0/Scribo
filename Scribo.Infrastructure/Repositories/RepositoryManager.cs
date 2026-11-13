using Scribo.Core.Interfaces;


namespace Scribo.Infrastructure.Repositories
{
    public class RepositoryManager(RepositoryContext context) : IRepositoryManager
    {
        private readonly RepositoryContext _context = context;
        private readonly Lazy<ILectureRecordRepository> _lectureRecordRepository = new(() => new LectureRecordRepository(context));

        public ILectureRecordRepository LectureRecord => _lectureRecordRepository.Value;
        public void Save() => _context.SaveChanges();
    }
}

