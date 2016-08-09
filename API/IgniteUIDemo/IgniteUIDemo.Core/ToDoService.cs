using System.Collections.Generic;
using IgniteUIDemo.Core.Entities;
using IgniteUIDemo.Core.Persistence;

namespace IgniteUIDemo.Core
{
    public interface IToDoService
    {
        int Create(ToDoItem toDoItem);
        IEnumerable<ToDoItem> Get();
        ToDoItem Get(int id);
        int Save(int id, ToDoItem toDoItem);
        void Delete(int id);
    }

    public class ToDoService : IToDoService
    {
        private readonly IRepository _repository;

        public ToDoService(IRepository repository)
        {
            _repository = repository;
        }

        public int Create(ToDoItem toDoItem)
        {
            return _repository.Create(toDoItem);
        }

        public IEnumerable<ToDoItem> Get()
        {
            return _repository.Get();
        }

        public ToDoItem Get(int id)
        {
            return _repository.Get(id);
        }

        public int Save(int id, ToDoItem toDoItem)
        {
            return _repository.Save(id, toDoItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
