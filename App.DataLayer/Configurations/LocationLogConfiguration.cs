using System;
using System.Collections.Generic;
using System.Text;
using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.DataLayer.Configurations
{
    public class LocationLogConfiguration : IEntityTypeConfiguration<LocationLog>
    {
        public void Configure(EntityTypeBuilder<LocationLog> builder)
        {
        }
    }
}
