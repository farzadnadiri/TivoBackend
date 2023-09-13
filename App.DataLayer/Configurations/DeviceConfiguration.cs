using System;
using System.Collections.Generic;
using System.Text;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.DataLayer.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {

            builder.HasOne(device => device.Car).WithOne(car => car.Device)
                .HasForeignKey<Car>(car => car.DeviceId);
            builder.Property(device => device.MacAddress).IsRequired();
        }
    }
}
