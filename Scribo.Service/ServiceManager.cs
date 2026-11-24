using AutoMapper;
using Scribo.Core.Interfaces;

namespace Scribo.Service
{
    public class ServiceManager(IRepositoryManager repositoryManager,IMapper mapper, 
        IAudioTranscriptionService transcriptionService, ITextSummarizationService summarizationService) : IServiceManager
    {
        private readonly Lazy<ILectureService> _lectureService = new(() => new LectureService(repositoryManager,mapper
            , transcriptionService, summarizationService));
        public ILectureService LectureService => _lectureService.Value;
    }
}
