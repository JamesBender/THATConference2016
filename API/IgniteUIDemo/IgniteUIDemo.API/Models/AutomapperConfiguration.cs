using AutoMapper;

namespace IgniteUIDemo.API.Models
{
    public static class AutomapperConfiguration
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ViewModels.ToDoItem, Core.Entities.ToDoItem>();
                cfg.CreateMap<Core.Entities.ToDoItem, ViewModels.ToDoItem>();
            });
        }
    }
}