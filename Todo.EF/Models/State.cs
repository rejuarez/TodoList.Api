using System.Collections.Generic;

namespace Todo.Core.Models
{
    public class State
    {
        public State()
        {
            TodoTasks = new HashSet<TodoTask>();
        }
        public string Code { get; set; }
        public int StateID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TodoTask> TodoTasks { get; set; }
    }
}
