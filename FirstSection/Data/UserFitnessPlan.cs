namespace FirstSection.Data
{
    public class UserFitnessPlan
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public APIUser User { get; set; }

        public Guid TrainingId { get; set; }
        public Training? Training { get; set; }

    }
}
