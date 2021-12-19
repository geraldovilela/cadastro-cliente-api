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
    }
}
