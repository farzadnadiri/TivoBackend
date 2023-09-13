using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.ViewModels
{
    public class DevicePacket
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Long { get; set; }
        [Required]
        public double Direction { get; set; }
        [Required]
        public double Speed { get; set; }
        [Required]
        public double Odometry { get; set; }
        [Required]
        public long DateTime { get; set; }
            
    }
}
