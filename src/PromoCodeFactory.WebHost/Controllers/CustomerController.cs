using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PromoCodeFactory.WebHost.Models;

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
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
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

            };

            await _customerRepository.CreateAsync(customer);
            return Created();
        }

        /// <summary>
        /// Обновляет клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] CustomerCreateDto dto)
        {
            if (_customerRepository.GetByIdAsync(id) == null)
                return NotFound();

            var customer = new Customer()
            {

            };

            await _customerRepository.UpdateAsync(id, customer);
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
