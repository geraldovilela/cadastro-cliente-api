using cadastro_cliente.repository.Context;
using cadastro_cliente.repository.Interfaces;
using cadastro_cliente_repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_cliente.repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _dbContext;

        public CustomerRepository(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> SaveCustomer(Customer customer)
        {
            await _dbContext.AddAsync(customer);
            _dbContext.SaveChanges();
            return customer;
        }
    }
}
