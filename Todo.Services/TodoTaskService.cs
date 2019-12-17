using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Core.Models;

namespace Todo.Services
{
    public class TodoTaskService : ITodoTaskService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TodoTaskService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<TodoTask> CreateTodoTask(TodoTask newTodoTask)
        {
            await _unitOfWork.TodoTasks.AddAsync(newTodoTask);
            await _unitOfWork.CommitAsync();
            return newTodoTask;
        }

        public async Task DeleteTodoTask(TodoTask todoTask)
        {
            _unitOfWork.TodoTasks.Remove(todoTask);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetAllWithStateAsync()
        {

            return await _unitOfWork.TodoTasks
                .GetAllWithStateAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetByParams(int? CategoryID, string Description, bool? IsActive)
        {
            return await _unitOfWork.TodoTasks
                .GetByParams(CategoryID, Description, IsActive);
        }

        public async Task<TodoTask> GetTodoTaskById(int id)
        {
            return await _unitOfWork.TodoTasks
                .GetByIdAsync(id);
        }

        public async Task UpdateStatusTodoTask(TodoTask todoTaskToBeUpdated, TodoTask todoTask)
        {
            todoTaskToBeUpdated.IsActive = todoTask.IsActive;
            todoTaskToBeUpdated.LastModifiedDate = todoTask.LastModifiedDate;
            await _unitOfWork.CommitAsync();
        }
    }
}
