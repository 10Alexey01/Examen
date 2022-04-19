using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public DateTime Day { get; set; }
        public bool Done { get; set; }

        public Task(string _Title, DateTime _Day)
        {
            Title = _Title;
            Day = _Day;
        }

    }
}
