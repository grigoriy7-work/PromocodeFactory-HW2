using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Dto
{
    public class PreferenceDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
