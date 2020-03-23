using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(movie => movie.Title)
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(movie => movie.Description)
                .HasMaxLength(555);
            builder.Property(movie => movie.Poster)
                .HasMaxLength(500);
        }
    }
}
