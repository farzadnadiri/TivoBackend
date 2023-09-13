using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewModels
{
    public class LocationLogViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [Display(Name = "عرض جغرافیایی")]
        public double Lat { get; set; }
        [Required]
        [Display(Name = "طول جغرافیایی")]
        public double Long { get; set; }

        [Required]
        [Display(Name = "زاویه")]
        public double Direction { get; set; }

        [Required]
        [Display(Name = "سرعت")]
        public int Speed { get; set; }
        [Required]
        [Display(Name = "مسافت طی شده")]
        public long Odometer { get; set; }
        [Required]
        [Display(Name = "زمان")]
        public string Time { get; set; }

    }
}
