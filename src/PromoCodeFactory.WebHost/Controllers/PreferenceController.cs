using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Dto;
using System;
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
        public async Task<IEnumerable<PreferenceResponse>> GetAllAsync()
        {
            var preferences = await _preferenceRepository.GetAllAsync();

            var responces = preferences.Select(x => new PreferenceResponse()
            {
                Id = x.Id,
                Name = x.Name
            });

            return responces;
        }

        /// <summary>
        /// Создаёт предпочтение
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] PreferenceDto dto)
        {
            var preference = new Preference()
            {
                Name = dto.Name,
            };

            await _preferenceRepository.CreateAsync(preference);
            return Created();
        }

        /// <summary>
        /// Обновляет предпочтение
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] PreferenceDto dto)
        {
            var preference = await _preferenceRepository.GetByIdAsync(id);
            if (preference == null)
                return NotFound();

            preference.Name = dto.Name;

            await _preferenceRepository.UpdateAsync(preference);
            return Ok();
        }

        /// <summary>
        /// Удаляет предпочтение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (_preferenceRepository.GetByIdAsync(id) == null)
                return NotFound();

            await _preferenceRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
