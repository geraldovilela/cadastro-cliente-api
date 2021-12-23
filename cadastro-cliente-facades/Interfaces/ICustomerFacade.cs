
using cadastro_cliente_repository.DTOs;
using cadastro_cliente_repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastro_cliente_facades.Interfaces
{
    public interface ICustomerFacade
    {
        public Task<Customer> CreateCustomer(CustomerDTO data);

        public Task DeleteCustomer(CustomerDTO data);
        public Task<List<Customer>> GetAll();
        public Task<Customer> GetById(string id);
        public Task<List<PhoneNumber>> GetPhonesById(string id);
    }
}
