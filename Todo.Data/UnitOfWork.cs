using System.Threading.Tasks;
using Todo.Core;
using Todo.Core.Repositories;
using Todo.Data.Repositories;

namespace Todo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _context;
        private TodoTaskRepository _todoTaskRepository;
        private CategoryRepository _categoryRepository;
        //private ArtistRepository _artistRepository;

        public UnitOfWork(TodoDbContext context)
        {
            this._context = context;
        }

        public ITodoTaskRepository TodoTasks => _todoTaskRepository = _todoTaskRepository ?? new TodoTaskRepository(_context);
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
