using AutoMapper;
using Todo.Api.Extensions;
using Todo.Api.Resources;
using Todo.Core.Models;

namespace Todo.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<TodoTaskResource, TodoTask>().
            ForMember(x => x.FileName, opt => opt.MapFrom(src => src.Document.FileName)).
            ForMember(x => x.FileContent, opt => opt.MapFrom(src => src.Document.OpenReadStream().ToByteArray())).
            ForMember(x => x.FileContentType, opt => opt.MapFrom(src => src.Document.ContentType));

            CreateMap<TodoTask, TodoTaskResource>();
        }
    }
}
