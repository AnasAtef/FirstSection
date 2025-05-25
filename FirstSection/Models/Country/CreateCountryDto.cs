using System.ComponentModel.DataAnnotations;
namespace FirstSection.Models.Country
{
    public class CreateCountryDto: BaseCountryDto
    {
        public int Id { get; set; }
    }
}
