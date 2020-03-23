using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class FoodProductsConfiguration : IEntityTypeConfiguration<FoodProducts>
    {
        public void Configure(EntityTypeBuilder<FoodProducts> builder)
        {
            builder.Property(movie => movie.ProductName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(n => n.ProductPrice)
                .HasColumnType("decimal(32,2)");
        }
    }
}
