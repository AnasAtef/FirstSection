using System.ComponentModel.DataAnnotations;

namespace FirstSection.Models.Training
{
    public class BaseTrainingDto
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public int FitnessCategoryId { get; set; }
    }
}
