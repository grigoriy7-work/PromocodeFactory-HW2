using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Dto
{
    public class PrefernceResponse
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
