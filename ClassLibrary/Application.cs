using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Application
    {
        private static Application application;
        public List<TaskList> taskLists { get; set; }

        public Application()
        {
            List<Task> List1 = new List<Task>()
            {
                new Task( "Сделать то-то",DateTime.Now),
                new Task( "И это сделать",DateTime.Now),
                new Task( "А еще это сделать",DateTime.Now)
            };
            List<Task> List2 = new List<Task>()
            {
                new Task( "Тоже можно сделать",DateTime.Now),
                new Task( "Необъязательно делать",DateTime.Now),
                new Task( "Желательно выполнить",DateTime.Now)
            };
            List<Task> List3 = new List<Task>()
            {
                new Task( "Попробую завершить",DateTime.Now),
            };

            taskLists = new List<TaskList>()
            {
                new TaskList(List1, "Входящие"),
                new TaskList(List2, "Сегодня"),
                new TaskList(List3, "Предстоящие")
            };

        }

        public static Application GetApplication()
        {
            if (application == null)
            {
                application = new Application();
            }
            return application;
        }
    }
}
