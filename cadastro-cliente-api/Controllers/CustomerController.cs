using cadastro_cliente_facades.Interfaces;
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
        public IActionResult<CustomerDTO>

    }
}
