using System.ComponentModel.DataAnnotations;

namespace HealthCare.Areas.SelectDisease.Models
{
    public class SelectDiseaseModel
    {

        [Required]
        public int? SelectID { get; set; }
        [Required]
        public int? DiseaseID { get; set; }
        [Required]
        public int? DoctorID { get; set; }

    }
}
