namespace FirstSection.Models.UserFitnessPlan
{
    public class GetUserFitnessPlanDto: BaseUserFitnessPlanDto
    {
        public Guid Id { get; set; }

        public string FitnessCategoryName { get; set; }

        public string TrainingName { get; set; }

        public  int NumberOfDays { get; set; }



    }
}
