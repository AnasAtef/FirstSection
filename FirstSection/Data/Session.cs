using System.ComponentModel.DataAnnotations;

namespace FirstSection.Data
{
    public class Session
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public int NumberOfSets { get; set; }
        public string ImageUrl { get; set; }

    }
}
