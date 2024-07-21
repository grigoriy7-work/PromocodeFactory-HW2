using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PromoCodesController : ControllerBase
    {
        private readonly IRepository<PromoCode> _promoCodeRepository;
        private readonly IRepository<Preference> _preferenceRepository;
        private readonly IRepository<Customer> _customerRepository;

        public PromoCodesController(IRepository<PromoCode> promoCodeRepository,
            IRepository<Preference> preferenceRepository,
            IRepository<Customer> customerRepository)
        {
            _promoCodeRepository = promoCodeRepository;
            _preferenceRepository = preferenceRepository;
            _customerRepository = customerRepository;

        }

        /// <summary>
        /// Получает промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPromoCodesAsync()
        {
            var promoCodes = await _promoCodeRepository.GetAllAsync();
            var response = promoCodes
                .Select(x => new PromoCodeResponse
                {
                    Code = x.Code,
                    ServiceInfo = x.ServiceInfo,
                    BeginDate = x.BeginDate.ToShortDateString(),
                    EndDate = x.EndDate.ToShortDateString(),    
                    PartnerName = x.PartnerName,
                    Preference = new PreferenceResponse
                    {
                        Id = x.Preference.Id,
                        Name = x.Preference.Name,
                    },
                    Customer = new CustomerShortRespons
                    {
                        Id = x.CustomerId,
                        FirstName = x.Customer.FirstName,
                        LastName = x.Customer.LastName,
                        Email = x.Customer.Email,
                    }
                });

            return Ok(response);
        }

        /// <summary>
        /// Создаёт промокод и добавляет его клиентам по предпочтению
        /// </summary>
        /// <returns>Статус запроса</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GivePromocodesToCustomersWithPreferenceAsync(PromoCodeRequest promoCodeRequest)
        {
            var preference = await _preferenceRepository.GetByIdAsync(promoCodeRequest.PreferenceId);
            if (preference == null)
                return NotFound();

            var customers = await _customerRepository.GetAllAsync();
            var customer = customers
                .Include(c => c.CustomerPreferences)
                .FirstOrDefault(c => c.CustomerPreferences.Any(p => p.PreferenceId == promoCodeRequest.PreferenceId));

            if (customer == null)
                return NotFound();

            var promoCode = new PromoCode()
            {
                Code = promoCodeRequest.Code,
                ServiceInfo = promoCodeRequest.ServiceInfo,
                BeginDate = promoCodeRequest.BeginDate,
                EndDate = promoCodeRequest.EndDate,
                PartnerName = promoCodeRequest.PartnerName,
                Preference = preference,
                Customer = customer
            };

            await _promoCodeRepository.CreateAsync(promoCode);
            return Created();
        }
    }
}