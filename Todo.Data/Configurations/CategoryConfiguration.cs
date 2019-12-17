using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Models;

namespace Todo.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryID = 1, Name = "Work", IconName = "bulb-outline" },
                new Category { CategoryID = 2, Name = "Family", IconName = "person-done-outline" },
                new Category { CategoryID = 3, Name = "Vacation", IconName = "map-outline" },
                new Category { CategoryID = 4, Name = "Shopping", IconName = "browser-outline" },
                new Category { CategoryID = 5, Name = "Movies", IconName = "film-outline" }
            );
            builder
                .HasKey(a => a.CategoryID);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
               .Property(m => m.IconName)
               .IsRequired()
               .HasMaxLength(50);

            builder
                .ToTable("Category");
        }
    }
}
