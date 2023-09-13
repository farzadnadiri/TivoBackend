using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.ViewModels
{
    public class CarViewModel
    {
        [HiddenInput]
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


        [Required(ErrorMessage = "(*)")]
        [Display(Name = "دستگاه")]
        public int DeviceId { get; set; }

    }
}
