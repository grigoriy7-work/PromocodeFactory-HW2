using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Получает всех клиентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            var responces = customers
                .Include(x => x.CustomerPreferences)
                .Select(x => new CustomerResponse()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Preferences = x.CustomerPreferences.Select(p => new PreferenceResponse
                {
                    Id = p.PreferenceId,
                    Name = p.Preference.Name
                }),
                PromoCodes = x.PromoCodes.Select(p => new PromoCodeShortResponse
                {
                    Id = p.Id,
                    Code = p.Code,
                    ServiceInfo = p.ServiceInfo,
                    BeginDate = p.BeginDate.ToShortDateString(),
                    EndDate = p.EndDate.ToShortDateString(),
                    PartnerName = p.PartnerName
                })
            });

            return responces;
        }

        /// <summary>
        /// Извлекает клиента по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerResponse>> GetByIdAsync(Guid id)
        {
            var customer = (await _customerRepository.GetAllAsync())
                .Include(x => x.CustomerPreferences)
                .ThenInclude(x => x.Preference)
                .FirstOrDefault(x => x.Id == id);

            if (customer == null)
                return NotFound();

            var customerResponse = new CustomerResponse()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Preferences = customer.CustomerPreferences
                .Select(p => new PreferenceResponse
                {
                    Id = p.PreferenceId,
                    Name = p.Preference.Name
                }),
            };

            return Ok(customerResponse);
        }

        /// <summary>
        /// Создаёт клиента
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CustomerCreateDto dto)
        {
            var customer = new Customer()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email, 
                CustomerPreferences = dto.PreferenceIdList.Select(x => new CustomerPreference { PreferenceId = x }).ToList(),
            };

            await _customerRepository.CreateAsync(customer);
            return Created();
        }

        /// <summary>
        /// Обновляет клиента
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CustomerUpdateDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(dto.Id);
            if (customer == null)
                return NotFound();
    
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;

            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }

        /// <summary>
        /// Удаляет клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            foreach (var promoCode in customer.PromoCodes)
            {
                customer.PromoCodes.Remove(promoCode);
            };
            await _customerRepository.DeleteAsync(id);
            
            return NoContent();    
        }
    }
}
