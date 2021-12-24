using cadastro_cliente.repository.Context;
using cadastro_cliente.repository.Interfaces;
using cadastro_cliente_repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Customer>> GetAll()
        {

            var customers = _dbContext.Customer.Where(customer => customer.Id != null).ToList<Customer>();
            return customers;
        }

        public async Task<Customer> GetById(string id)
        {
            Guid guid = new(id);
            var customers = await _dbContext.Customer.FindAsync(guid);
            return customers;
        }

        public async Task<List<PhoneNumber>> GetPhonesById(string id)
        {
            var phone = _dbContext.PhoneNumbers.FromSqlRaw($"SELECT * FROM[CustomersDB].[dbo].[phone_number] where[CustomersDB].[dbo].[phone_number].CustomerId = '{id}'");
            return phone.ToList();

        }
        public async Task<List<Address>> GetAddressById(string id)
        {
            var addresses = _dbContext.Adresses.FromSqlRaw($"SELECT * FROM[CustomersDB].[dbo].[address] where[CustomersDB].[dbo].[address].CustomerId = '{id}'");
            return addresses.ToList();
        }
    }
}
