using System.ComponentModel.DataAnnotations;

namespace HealthCare.Areas.US_Patient.Models
{
	public class PatientModel
	{
        public int? PatientID { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public DateTime? Birthdate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string address { get; set; }
    }
}
