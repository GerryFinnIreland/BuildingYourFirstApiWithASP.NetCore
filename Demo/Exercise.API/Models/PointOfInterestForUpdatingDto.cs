using System.ComponentModel.DataAnnotations;

namespace Exercise.API.Models
{
    public class PointOfInterestForUpdatingDto
    {
        [Required(ErrorMessage = "A Name Value is Required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
