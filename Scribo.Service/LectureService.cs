using AutoMapper;
using Scribo.Core.Dtos;
using Scribo.Core.Interfaces;
using Scribo.Core.Models;

namespace Scribo.Service
{
    public class LectureService(IRepositoryManager repositoryManager,IMapper mapper, 
        IAudioTranscriptionService transcriptionService, ITextSummarizationService summarizationService) : ILectureService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IMapper _mapper = mapper;
        private readonly IAudioTranscriptionService _transcriptionService = transcriptionService;
        private readonly ITextSummarizationService _summarizationService = summarizationService;

        public async Task<LectureRecordDto> CreateLectureRecordAsync(LectureRecordForCreationDto recordDto)
        {
            var rawTranscript = await _transcriptionService.TranscribeAudioAsync(recordDto.AudioFile);
         
            var formattedNotes = await _summarizationService.SummarizeLectureAsync(
                rawTranscript,
                recordDto.CourseName,
                recordDto.Subject);

            var entity = _mapper.Map<LectureRecord>(recordDto);
            entity.FormattedNotes = formattedNotes;

            _repositoryManager.LectureRecord.Create(entity);
            await _repositoryManager.SaveAsync(); 

            return _mapper.Map<LectureRecordDto>(entity);
        }

        public async Task<IEnumerable<LectureRecordDto>> GetAllLectureRecordsByCourseNameAsync(string courseName, DateTime? date, bool trackChanges)
        {
            var records = await _repositoryManager.LectureRecord.GetLectureRecordsByCourseAsync(courseName, date, trackChanges);
            return _mapper.Map<IEnumerable<LectureRecordDto>>(records);
        }

        public async Task<LectureRecordDto> GetSingleLectureRecordAsync(int id, bool trackChanges)
        {
            var records = await _repositoryManager.LectureRecord.GetSingleLectureRecordAsync(id, trackChanges) ?? throw new Exception("Kayit bulunamadi");
            return _mapper.Map<LectureRecordDto>(records);

        }

    }
}
