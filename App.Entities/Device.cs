using System;
using System.Collections.Generic;
using System.Text;
using App.Entities.AuditableEntity;

namespace App.Entities
{
    public class Device:IAuditableEntity
    {
        public Device()
        {

        }

        public int Id { get; set; }
        public string MacAddress { get; set; }
        public int Version { get; set; }
        public string FirmwareVersion { get; set; }
        public virtual Car Car { get; set; }
    }
}
