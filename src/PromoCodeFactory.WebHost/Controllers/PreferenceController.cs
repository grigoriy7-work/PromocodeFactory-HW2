using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.WebHost.Models.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly IRepository<Preference> _preferenceRepository;

        public PreferenceController(IRepository<Preference> preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        /// <summary>
        /// Получает все предпочтения
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PrefernceResponse>> GetAllAsync()
        {
            var preferences = await _preferenceRepository.GetAllAsync();

            var responces = preferences.Select(x => new PrefernceResponse()
            {
                Name = x.Name
            });

            return responces;
        }
    }
}
