using Scribo.Core.Dtos;
using Scribo.Core.Models;

namespace Scribo.Core.Interfaces
{
    public interface ILectureService
    {
        LectureRecordDto GetSingleLectureRecord(int id,bool trackChanges);
        IEnumerable<LectureRecordDto> GetAllLectureRecordsByCourseName(string courseName,bool trackChanges);
        LectureRecordDto CreateLectureRecord(LectureRecordForCreationDto recordDto);

    }
}
