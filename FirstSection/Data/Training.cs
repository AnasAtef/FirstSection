namespace FirstSection.Data
{
    public class Training
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required int NumberOfDays { get; set; }

        public int FitnessCategoryId { get; set; }
        public FitnessCategory? FitnessCategory { get; set; }
    }
}
