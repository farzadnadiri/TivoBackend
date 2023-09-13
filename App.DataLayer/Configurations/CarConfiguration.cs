using System;
using System.Collections.Generic;
using System.Text;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.DataLayer.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            
          
            builder.Property(car => car.Driver).HasMaxLength(450).IsRequired();
        }
    }
}
