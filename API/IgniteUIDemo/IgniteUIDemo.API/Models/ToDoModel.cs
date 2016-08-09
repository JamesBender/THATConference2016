using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IgniteUIDemo.Core;

namespace IgniteUIDemo.API.Models
{
    public interface IToDoModel
    {
        int Create(ViewModels.ToDoItem toDoItem);
        IEnumerable<ViewModels.ToDoItem> Get();
        ViewModels.ToDoItem Get(int id);
        int Save(int id, ViewModels.ToDoItem toDoItem);
        void Delete(int id);
    }

    public class ToDoModel : IToDoModel
    {
        private readonly IToDoService _toDoService;

        public ToDoModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public int Create(ViewModels.ToDoItem toDoItem)
        {
            return _toDoService.Create(Mapper.Map<ViewModels.ToDoItem, Core.Entities.ToDoItem>(toDoItem));
        }

        public IEnumerable<ViewModels.ToDoItem> Get()
        {
            var listOfToDoItems = _toDoService.Get();

            return listOfToDoItems.Select(Mapper.Map<Core.Entities.ToDoItem, ViewModels.ToDoItem>).ToList();
        }

        public ViewModels.ToDoItem Get(int id)
        {
            return Mapper.Map<Core.Entities.ToDoItem, ViewModels.ToDoItem>(_toDoService.Get(id));
        }

        public int Save(int id, ViewModels.ToDoItem toDoItem)
        {
            toDoItem.Id = id;
            return _toDoService.Save(id, Mapper.Map<ViewModels.ToDoItem, Core.Entities.ToDoItem>(toDoItem));
        }

        public void Delete(int id)
        {
            _toDoService.Delete(id);
        }
    }
}