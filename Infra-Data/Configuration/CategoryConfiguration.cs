using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CategoryImage).HasMaxLength(500).IsRequired();

            builder.HasData(
                new Category(1, "Smartphones", "https://images.unsplash.com/photo-1569040029205-a03a8b455808?q=80&w=1546&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
                new Category(2, "Fashion", "https://images.unsplash.com/photo-1537832816519-689ad163238b?q=80&w=1718&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
                new Category(3, "Games", "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?q=80&w=1547&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
        }
    }
}
