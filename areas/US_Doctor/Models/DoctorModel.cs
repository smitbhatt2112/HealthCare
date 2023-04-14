using System.ComponentModel.DataAnnotations;

namespace HealthCare.areas.US_Doctor.Models
{
    public class DoctorModel
    {
        public int? DoctorID { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string OfficeAddress { get; set; }
    }
    public class DoctorDropDownModel
    {
        public int? DoctorID { get; set; }
        [Required]
        public string DoctorName { get; set; }
    }
}
