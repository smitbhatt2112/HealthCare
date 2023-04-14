using System.ComponentModel.DataAnnotations;

namespace HealthCare.Areas.AssignDisease.Models
{
    public class AssignModel
    {
        [Required]
        public int? AssignID { get; set; }
        [Required]
        public int? DiseaseID { get; set; }
        [Required]
        public int? PatientID { get; set; }
    }
}
