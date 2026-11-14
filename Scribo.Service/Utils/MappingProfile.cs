using AutoMapper;
using Scribo.Core.Dtos;
using Scribo.Core.Models;

namespace Scribo.Service.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LectureRecord, LectureRecordDto>();
            CreateMap<LectureRecordForCreationDto, LectureRecord>();
        }
    }
}
