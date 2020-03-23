using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class FoodcourtCheckConfiguration : IEntityTypeConfiguration<FoodcourtCheck>
    {
        public void Configure(EntityTypeBuilder<FoodcourtCheck> builder)
        {
            builder.Property(n => n.PaidPrice)
                .HasColumnType("decimal(32,2)");
        }
    }
}
