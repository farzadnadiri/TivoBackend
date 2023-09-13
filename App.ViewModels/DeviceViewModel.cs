using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewModels
{
   public class DeviceViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "مک آدرس")]
        public string MacAddress { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نسخه سخت افزار")]
        public int Version { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نسخه نرم افزار")]
        public string FirmwareVersion { get; set; }
    }
}
