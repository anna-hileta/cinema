using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class CinemaLocationConfiguration : IEntityTypeConfiguration<CinemaLocation>
    {
        public void Configure(EntityTypeBuilder<CinemaLocation> builder)
        {
            builder.Property(h => h.CinemaName)
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(h => h.Address)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
