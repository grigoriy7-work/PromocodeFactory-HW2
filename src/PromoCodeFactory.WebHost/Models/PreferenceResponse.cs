using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class PreferenceResponse
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
