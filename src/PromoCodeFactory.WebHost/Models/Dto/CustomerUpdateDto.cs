using System;

namespace PromoCodeFactory.WebHost.Models.Dto
{
    public class CustomerUpdateDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
