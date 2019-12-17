using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Models;

namespace Todo.Core.Repositories
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
        Task<IEnumerable<TodoTask>> GetAllWithStateAsync();
        Task<IEnumerable<TodoTask>> GetByParams(int? CategoryID, string Description, bool? IsActive);
    }
}
