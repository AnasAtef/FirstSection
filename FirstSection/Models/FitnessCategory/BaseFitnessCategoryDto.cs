using System.ComponentModel.DataAnnotations;

namespace FirstSection.Models.FitnessCategory
{
    public class BaseFitnessCategoryDto
    {
        
        [Required]
        public  string Name { get; set; }
        public string? Description { get; set; }
    }
}
