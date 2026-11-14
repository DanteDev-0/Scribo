using AutoMapper;
using Scribo.Core.Interfaces;

namespace Scribo.Service
{
    public class ServiceManager(IRepositoryManager repositoryManager,IMapper mapper) : IServiceManager
    {
        private readonly Lazy<ILectureService> _lectureService = new(() => new LectureService(repositoryManager,mapper));
        public ILectureService LectureService => _lectureService.Value;
    }
}
