using System;
using System.Collections.Generic;
using System.Text;
using App.Entities.AuditableEntity;

namespace App.Entities
{
    public class Car: IAuditableEntity
    {
        public Car()
        {
            Events = new HashSet<Event>();
            LocationLogs=new HashSet<LocationLog>();
        }

        public int Id { get; set; }
        public string Driver { get; set;}
        public string Plate { get; set;}
        public string Type { get; set;}
        public string Color { get; set;}
        public int DeviceId  {get; set;}
        public virtual Device Device {get; set;}
        public virtual ICollection<Event> Events {get; set;}
        public virtual ICollection<LocationLog> LocationLogs {get; set;}

    }
}
