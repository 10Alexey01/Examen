using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TaskList
    {
        public Guid TaskListId { get; set; }
        public string TaskListName { get; set; }

        public List<Task> tasks { get; set; }

        public TaskList(List<Task> x, string _TaskListName)
        {
            tasks = x;
            TaskListName = _TaskListName;
        }

        public string GetName()
        {
            return TaskListName;
        }
    }
}
