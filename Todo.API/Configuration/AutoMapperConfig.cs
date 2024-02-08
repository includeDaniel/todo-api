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
            CreateMap<TodoModel, AddTodoRequestModel>().ReverseMap();
            CreateMap<TodoModel, TodoResponseModel>().ReverseMap();
            CreateMap<TodoViewModel, TodoResponseModel>().ReverseMap();
            CreateMap<UpdateTodoRequestModel, TodoResponseModel>().ReverseMap();
            CreateMap<UpdateTodoRequestModel, TodoModel>().ReverseMap();
        }
    }
}
     