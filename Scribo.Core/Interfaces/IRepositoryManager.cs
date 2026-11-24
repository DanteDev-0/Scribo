namespace Scribo.Core.Interfaces
{
    public interface IRepositoryManager
    {
        ILectureRecordRepository LectureRecord { get; }
        Task SaveAsync();
    }
}
