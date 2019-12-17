using System.Collections.Generic;

namespace Todo.Core.Models
{
    public class Category
    {
        public Category()
        {
            TodoTasks = new HashSet<TodoTask>();
        }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public virtual ICollection<TodoTask> TodoTasks { get; set; }
    }
}
