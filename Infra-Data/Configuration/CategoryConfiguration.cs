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
                new Category(1, "Smartphones", "https://i5.walmartimages.com/seo/Straight-Talk-Apple-iPhone-12-64GB-Black-Prepaid-Smartphone-Locked-to-Straight-Talk_66b2853b-6cb5-4f20-b73a-b60b39b6de44.6b3bf83a920058a47342318925f1dc2b.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF"),
                new Category(2, "Fashion", "https://i5.walmartimages.com/seo/Reebok-Women-s-Flight-Jogger-with-Cargo-Pockets_eefde8e0-c787-48fc-962e-2d2d406391a1.70bc369116e0b1954b5eee14c1a67ea7.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF"),
                new Category(3, "Games", "https://i5.walmartimages.com/seo/Xbox-Series-X-Video-Game-Console-Black_9f8c06f5-7953-426d-9b68-ab914839cef4.5f15be430800ce4d7c3bb5694d4ab798.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF"));
        }
    }
}
