using System.ComponentModel.DataAnnotations;

namespace HealthCare.Areas.Diseases.Models
{
    public class DiseaseModel
    {
        public int? DiseaseID { get; set; }

        [Required]
        public string DiseaseName { get; set; }
    }

    public class DiseaseDropDownModel
    {
        public int? DiseaseID { get; set; }

        [Required]
        public string DiseaseName { get; set; }
    }
}
