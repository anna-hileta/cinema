using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
        public class CinemaHallConfiguration : IEntityTypeConfiguration<CinemaHall>
        {
            public void Configure(EntityTypeBuilder<CinemaHall> builder)
            {
                builder.Property(hall => hall.Name)
                    .HasMaxLength(32)
                    .IsRequired();
            }
        }
        
}
