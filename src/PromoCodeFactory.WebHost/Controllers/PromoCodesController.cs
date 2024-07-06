using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Domain;
using System.Collections;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PromoCodesController : ControllerBase
    {
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
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromocodesToCustomersWithPreferenceAsync()
        {

            return Created();
        }
    }
}
