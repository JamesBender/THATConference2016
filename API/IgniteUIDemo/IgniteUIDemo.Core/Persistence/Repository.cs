using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using IgniteUIDemo.Core.Entities;

namespace IgniteUIDemo.Core.Persistence
{
    public interface IRepository
    {
        IEnumerable<ToDoItem> Get();
        ToDoItem Get(int id);
        int Create(ToDoItem toDoItem);
        int Save(int id, ToDoItem toDoItem);
        void Delete(int id);
    }

    public class Repository : IRepository
    {
        private readonly IDictionary<int, ToDoItem> _datastore = new ConcurrentDictionary<int, ToDoItem>();

        public IEnumerable<ToDoItem> Get()
        {
            return _datastore.Values.ToList();
        }

        public ToDoItem Get(int id)
        {
            if (_datastore.ContainsKey(id))
            {
                return _datastore[id];
            }

            return null;
        }

        public int Create(ToDoItem toDoItem)
        {
            toDoItem.Id = _datastore.Values.Count + 1;
            _datastore.Add(toDoItem.Id, toDoItem);
            return toDoItem.Id;
        }

        public int Save(int id, ToDoItem toDoItem)
        {
            if (_datastore.ContainsKey(id))
            {
                _datastore[id] = toDoItem;

                return id;
            }

            throw new ArgumentOutOfRangeException(nameof(id), "that key wasn't in the list");
        }

        public void Delete(int id)
        {
            _datastore.Remove(id);
        }
    }
}
