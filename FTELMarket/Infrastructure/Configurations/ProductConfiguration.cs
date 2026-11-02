namespace FTELMarket.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
  

    namespace FTELMarket.Infrastructure.Configurations
    {
        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.Property(p => p.Name)
                       .IsRequired()
                       .HasMaxLength(200);


                builder.Property(p => p.Description)
                       .IsRequired(false);


                builder.HasOne(p => p.Category)
                       .WithMany(c => c.Products)
                       .HasForeignKey(p => p.CategoryId)
                       .IsRequired();
            }
        }
    }
}
