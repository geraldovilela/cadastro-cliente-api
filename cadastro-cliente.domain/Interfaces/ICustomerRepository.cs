using cadastro_cliente_repository.DTOs;
using cadastro_cliente_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_cliente.repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> SaveCustomer(Customer customer);

        Task<List<Customer>> GetAll();

        Task<Customer> GetById(string id);

        Task<List<PhoneNumber>> GetPhonesById(string id);

        Task<List<Address>> GetAddressById(string id);

        Task<Customer> UpdateCustomer(string id, Customer customer);
    }
}
