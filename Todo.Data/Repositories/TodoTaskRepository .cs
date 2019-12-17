using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Core.Models;
using Todo.Core.Repositories;

namespace Todo.Data.Repositories
{
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(TodoDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<TodoTask>> GetAllWithStateAsync()
        {
            return await TodoDbContext.TodoTasks
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetByParams(int? CategoryID, string? Description, bool? IsActive)
        {
            return await TodoDbContext.TodoTasks
                .Where(x => x.CategoryId == ((CategoryID == null) ? x.CategoryId : CategoryID))
                .Where(x => x.Description.Contains((!string.IsNullOrEmpty(Description)) ? Description : x.Description))
                .Where(x => x.IsActive == ((IsActive == null) ? x.IsActive : IsActive)).OrderByDescending(x => x.CreationDate)
                    .ToListAsync();
        }

        private TodoDbContext TodoDbContext
        {
            get { return Context as TodoDbContext; }
        }
    }
}
