using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class CountryOfOriginConfiguration : IEntityTypeConfiguration<CountryOfOrigin>
    {
        public void Configure(EntityTypeBuilder<CountryOfOrigin> builder)
        {
            builder.Property(h => h.Name)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
