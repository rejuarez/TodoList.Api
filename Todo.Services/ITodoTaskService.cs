using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Models;

namespace Todo.Services
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTask>> GetAllWithStateAsync();
        Task<IEnumerable<TodoTask>> GetByParams(int? CategoryID, string Description, bool? IsActive);
        Task<TodoTask> GetTodoTaskById(int id);
        Task<TodoTask> CreateTodoTask(TodoTask newTodoTask);
        Task UpdateStatusTodoTask(TodoTask todoTaskToBeUpdated, TodoTask todoTask);
        Task DeleteTodoTask(TodoTask todoTask);
    }
}
