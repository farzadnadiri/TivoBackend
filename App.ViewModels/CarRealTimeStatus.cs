using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.ViewModels
{
    public class CarRealTimeStatus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام راننده")]
        public string Driver { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "شماره پلاک")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نوع خودرو")]
        public string Type { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "رنگ خودرو")]
        public string Color { get; set; }

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
        [Display(Name = "مسافت")]
        public long Odometer { get; set; }

        [Required]
        [Display(Name = "آپدیت شده")]
        public bool IsFresh { get; set; }


    }
}
