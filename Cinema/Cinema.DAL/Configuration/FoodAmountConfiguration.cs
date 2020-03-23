using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Configuration
{
    public class FoodAmountConfiguration : IEntityTypeConfiguration<FoodAmount>
    {
        public void Configure(EntityTypeBuilder<FoodAmount> builder)
        {
        }
    }
}
