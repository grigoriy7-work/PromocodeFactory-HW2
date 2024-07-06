using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models.Dto;
using System.Collections;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PromoCodesController : ControllerBase
    {
        private readonly IRepository<PromoCode> _promoCodeRepository;
        private readonly IRepository<Preference> _preferenceRepository;

        public PromoCodesController(IRepository<PromoCode> promoCodeRepository, IRepository<Preference> preferenceRepository)
        {
            _promoCodeRepository = promoCodeRepository;
            _preferenceRepository = preferenceRepository;
        }

        /// <summary>
        /// Получает промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPromoCodesAsync()
        {
            return Ok();
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

            if(await _preferenceRepository.GetByIdAsync(promoCodeRequest.PreferenceId) == null)
                return NotFound();

            var promoCode = new PromoCode()
            {
                Code = promoCodeRequest.Code,
                ServiceInfo = promoCodeRequest.ServiceInfo,
                BeginDate = promoCodeRequest.BeginDate,
                EndDate = promoCodeRequest.EndDate,
                PartnerName = promoCodeRequest.PartnerName,
                PreferenceId = promoCodeRequest.PreferenceId,
            };

            var model =  await _promoCodeRepository.CreateAsync(promoCode);

            return CreatedAtAction(nameof(GivePromocodesToCustomersWithPreferenceAsync), new { id = model.Id }, promoCode);
        }
    }
}
