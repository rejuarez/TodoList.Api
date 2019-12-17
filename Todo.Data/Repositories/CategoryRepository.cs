using Todo.Core.Models;
using Todo.Core.Repositories;

namespace Todo.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(TodoDbContext context)
            : base(context)
        { }
    }
}
