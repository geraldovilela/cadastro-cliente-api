using cadastro_cliente_facades.Interfaces;
using cadastro_cliente_repository.DTOs;
using cadastro_cliente_repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_cliente_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerFacade _customerFacade;

        public CustomerController(ICustomerFacade customerFacade)
        {
            _customerFacade = customerFacade;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CustomerDTO data)
        {
            var customer = await _customerFacade.CreateCustomer(data);
            
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Customer> customers = await _customerFacade.GetAll();

            return Ok(customers);
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetById([FromQuery] string id)
        {
            var customer = await _customerFacade.GetById(id);

            return Ok(customer);
        }

        [HttpGet("phone/id")]
        public async Task<ActionResult> GetPhonesById([FromQuery] string id)
        {
            var phones = await _customerFacade.GetPhonesById(id);

            return Ok(phones);
        }
    }
}
