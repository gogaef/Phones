using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phones.Infrastrructure.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("phones");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Color)
                .HasMaxLength(256)
                .HasColumnName("color")
                .IsRequired();

            builder.Property(x => x.Model)
                .HasMaxLength(256)
                .HasColumnName("model")
                .IsRequired();

            builder.Property(x => x.OSType)
                .HasMaxLength(256)
                .HasColumnName("operation_system_type")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasMaxLength(256)
                .HasColumnName("type")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(18, 6)
                .HasColumnName("color")
                .IsRequired();

            builder.HasOne<Brand>(p => p.Brand)
                    .WithOne(b => b.Id)
                    .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

        }
    }
}

