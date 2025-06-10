using Microsoft.Build.Framework;

namespace FirstSection.Models.Training
{
    public class CreateTrainingDto: BaseTrainingDto
    {
        public Guid Id { get; set; }
    }
}
