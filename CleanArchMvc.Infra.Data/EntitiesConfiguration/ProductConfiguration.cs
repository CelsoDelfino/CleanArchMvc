using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_=> _.Name).HasMaxLength(100).IsRequired();
            builder.Property(_=> _.Description).HasMaxLength(200).IsRequired();

            builder.Property(_ => _.Price).HasPrecision(10,2);

            builder.HasOne(_ => _.Category).WithMany(_ => _.Products).HasForeignKey(_ => _.CategoryId);
        }
    }
}
