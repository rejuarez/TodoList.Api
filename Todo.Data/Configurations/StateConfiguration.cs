using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Models;

namespace Todo.Data.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {

            builder.HasData(
                new State { StateID = 1, Description = "Active", Code = "ACT" },
                new State { StateID = 2, Description = "InActive", Code = "IN" }
            );
            builder
                .HasKey(a => a.StateID);

            builder
                .Property(m => m.StateID)
                .UseIdentityColumn();

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("State");
        }
    }
}
