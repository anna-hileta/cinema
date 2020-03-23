using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class CheckConfiguration : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {
            builder.Property(n => n.PaidPrice)
                .HasColumnType("decimal(32,2)");
        }
    }
}
