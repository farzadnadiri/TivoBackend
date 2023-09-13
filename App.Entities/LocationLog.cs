using System;
using System.Collections.Generic;
using System.Text;
using App.Entities.AuditableEntity;

namespace App.Entities
{
    public class LocationLog : IAuditableEntity
    {
        public LocationLog()
        {

        }
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Direction { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public long Odometer { get; set; }
        public DateTime Time { get; set; }
        public virtual Car Car { get; set; }
    }
}
