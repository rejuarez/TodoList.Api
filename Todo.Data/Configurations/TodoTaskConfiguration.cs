using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Models;

namespace Todo.Data.Configurations
{
    public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder
                .HasKey(m => m.TodoTaskID);

            builder
                .Property(m => m.TodoTaskID)
                .UseIdentityColumn();

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .HasOne(m => m.Category)
                .WithMany(a => a.TodoTasks)
                .HasForeignKey(m => m.CategoryId);

            builder
                .ToTable("TodoTask");


        }
    }
}
