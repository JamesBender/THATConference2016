using System;
using System.Collections.Generic;

namespace IgniteUIDemo.Core.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public IList<ToDoItem> ChildTasks { get; private set; }

        public ToDoItem()
        {
            ChildTasks = new List<ToDoItem>();
        }
    }
}
