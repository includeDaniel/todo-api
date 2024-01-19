using AutoMapper;
using Todo.API.Controllers.Models;
using Todo.Business.Models;

namespace Todo.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TodoModel, TodoViewModel>().ReverseMap();
        }
    }
}
    