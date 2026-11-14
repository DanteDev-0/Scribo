using AutoMapper;
using Scribo.Core.Dtos;
using Scribo.Core.Interfaces;
using Scribo.Core.Models;
using System.Reflection.Metadata;

namespace Scribo.Service
{
    public class LectureService(IRepositoryManager repositoryManager,IMapper mapper) : ILectureService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IMapper _mapper = mapper;

        public LectureRecordDto CreateLectureRecord(LectureRecordForCreationDto recordDto)
        {
            var records = _mapper.Map<LectureRecord>(recordDto);
            _repositoryManager.LectureRecord.Create(records);
            _repositoryManager.Save();
            return _mapper.Map<LectureRecordDto>(records);
        }

        public IEnumerable<LectureRecordDto> GetAllLectureRecordsByCourseName(string courseName, bool trackChanges)
        {
            var records = _repositoryManager.LectureRecord.GetLectureRecordsByCourseName(courseName, trackChanges) ?? throw new Exception("kayit bulunamadi");
            return _mapper.Map<IEnumerable<LectureRecordDto>>(records);
        }

        public LectureRecordDto GetSingleLectureRecord(int id, bool trackChanges)
        {
            var records = _repositoryManager.LectureRecord.GetSingleLectureRecord(id, trackChanges) ?? throw new Exception("Kayit bulunamadi");
            return _mapper.Map<LectureRecordDto>(records);

        }
    }
}
