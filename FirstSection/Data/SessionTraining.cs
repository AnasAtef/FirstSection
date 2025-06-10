using System.ComponentModel.DataAnnotations;

namespace FirstSection.Data
{
    public class SessionTraining
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Session Session { get; set; }
        public Guid TrainingId { get; set; }
        public Training Training { get; set; }
        public int SequenceNumber { get; set; }
    }
}
