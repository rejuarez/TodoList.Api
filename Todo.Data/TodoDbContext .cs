using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;
using Todo.Data.Configurations;

namespace Todo.Data
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new TodoTaskConfiguration());
            builder
                .ApplyConfiguration(new CategoryConfiguration());

        }
    }
}
