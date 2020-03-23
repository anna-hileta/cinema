using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(w => w.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(w => w.Surname)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(w => w.FatherName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(w => w.Login)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(w => w.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
