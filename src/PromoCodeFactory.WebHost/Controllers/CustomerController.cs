using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Dto;

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
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        /// <summary>
        /// Извлекает клиента по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerResponse>> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            var customerResponse = new CustomerResponse()
            {

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

            await _customerRepository.UpdateAsync(customer);
            return Ok();
        }

        /// <summary>
        /// Удаляет клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (_customerRepository.GetByIdAsync(id) == null)
                return NotFound();

            await _customerRepository.DeleteAsync(id);
            return Ok();    
        }
    }
}
