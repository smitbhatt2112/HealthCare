using System.ComponentModel.DataAnnotations;

namespace HealthCare.Areas.DiseaseDevice.Models
{
    public class DiseaseDeviceModel
    {
        [Required]
        public int? AssignID { get; set; }
        [Required]
        public int? DeviceID { get; set; }
        public int? DiseaseID { get; set; }


    }
}
