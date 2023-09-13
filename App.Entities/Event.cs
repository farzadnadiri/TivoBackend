using System;
using System.Collections.Generic;
using System.Text;
using App.Entities.AuditableEntity;

namespace App.Entities
{
    public enum EventType
    {
        Brake,
        TakeOff,
    };

    public class Event : IAuditableEntity
    {

        public Event()
        {

        }

        public int Id { get; set; }
        public EventType Type { get; set; }

        public virtual Car Car { get; set; }

        public DateTime Time { get; set; }
    }
}
