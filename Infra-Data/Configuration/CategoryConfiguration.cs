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
                new Category(3, "Games", "https://i5.walmartimages.com/seo/Xbox-Series-X-Video-Game-Console-Black_9f8c06f5-7953-426d-9b68-ab914839cef4.5f15be430800ce4d7c3bb5694d4ab798.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF"),
                new Category(4, "Kitchen", "https://i5.walmartimages.com/seo/Carote-Nonstick-Pots-and-Pans-Set-10-Pcs-Granite-Stone-Kitchen-Cookware-Sets-White_efe69ee7-6273-4cbe-a436-149b7b1d0d0c.a2320ff6519d540c3df326c48fdef207.png?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF"),
                new Category(5, "Kids", "https://i5.walmartimages.com/seo/Friendship-Bracelet-Making-Kit-Girls-DIY-Craft-Kits-Toys-Cool-Arts-Crafts-Teen-Travel-Activity-Set-Gifts-Age-6-7-8-9-10-11-12-Year-Old_1c074238-f765-4bc9-bcd4-6aec3c63e831.61da6ea6dec87564dbe3452ae6d55039.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF"),
                new Category(6, "Electronic", "https://i5.walmartimages.com/seo/Acer-Nitro-31-5-1500R-Curved-Full-HD-1920-x-1080-Gaming-Monitor-Black-ED320QR-S3biipx_026e53ed-7591-4f39-afb1-d5575a7fc06a.fae36db73738179d935b7d5e64a5be51.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF"),
                new Category(7, "Furniture", "https://i5.walmartimages.com/seo/Intex-Corner-Sofa_b6271dd9-4704-436a-aa35-36293fa7482c_1.887862bad366185f36f3793d387c450e.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF")
                );
        }
    }
}
