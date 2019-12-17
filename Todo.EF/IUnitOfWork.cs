using System;
using System.Threading.Tasks;
using Todo.Core.Repositories;

namespace Todo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoTaskRepository TodoTasks { get; }
        ICategoryRepository Categories { get; }
        Task<int> CommitAsync();
    }
}
