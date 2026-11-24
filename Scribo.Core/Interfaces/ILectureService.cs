using Scribo.Core.Dtos;



namespace Scribo.Core.Interfaces
{
    public interface ILectureService
    {
        Task<LectureRecordDto> GetSingleLectureRecordAsync(int id,bool trackChanges);
        Task<IEnumerable<LectureRecordDto>> GetAllLectureRecordsByCourseNameAsync(string courseName,DateTime? date,bool trackChanges);
        Task<LectureRecordDto> CreateLectureRecordAsync(LectureRecordForCreationDto recordDto);

    }
}
