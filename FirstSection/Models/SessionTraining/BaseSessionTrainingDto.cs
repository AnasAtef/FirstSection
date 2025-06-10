namespace FirstSection.Models.Session
{
    public class BaseSessionTrainingDto
    {
        public Guid SessionId { get; set; }
        public Guid TrainingId { get; set; }
        public int SequenceNumber { get; set; }
    }
}
