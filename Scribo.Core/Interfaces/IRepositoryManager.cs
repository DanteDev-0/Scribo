namespace Scribo.Core.Interfaces
{
    public interface IRepositoryManager
    {
        ILectureRecordRepository LectureRecord { get; }
        void Save();
    }
}
