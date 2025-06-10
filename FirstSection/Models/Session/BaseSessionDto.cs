namespace FirstSection.Models.Session
{
    public class BaseSessionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public int NumberOfSets { get; set; }
        public string ImageUrl { get; set; }
    }
}
