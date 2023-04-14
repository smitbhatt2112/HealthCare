using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Areas.Devices.Models
{
    public class DevicesModel
    {
        public int? DeviceID { get; set; }
        [Required]
        public string DeviceName { get; set; }
        [Required]
        public string DeviceBrand { get; set; }
        [Required]
        public IFormFile? File { get; set; }
      
        public string? PhotoPath { get; set; }
       
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
    public class DeviceDropDownModel
    {
        public int? DeviceID { get; set; }
        [Required]
        public string DeviceName { get; set; }
    }
}
