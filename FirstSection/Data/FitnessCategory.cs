using System.ComponentModel.DataAnnotations;

namespace FirstSection.Data
{
    public class FitnessCategory
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

    }
}
