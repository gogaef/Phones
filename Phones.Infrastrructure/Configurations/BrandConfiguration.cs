using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phones.Domain.Entities;

namespace Phones.Infrastrructure.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand> 
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("brands");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Id)
                .HasColumnName("id");
        }
    }
}