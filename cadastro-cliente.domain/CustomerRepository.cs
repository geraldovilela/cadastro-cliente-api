using AutoMapper;
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
        private readonly IMapper _mapper;

        public CustomerRepository(CustomerContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<Customer> UpdateCustomer(string id, Customer customer)
        {
            Guid guid = new(id);
            var OldCustomer = await _dbContext.FindAsync<Customer>(guid);
            OldCustomer.Name = customer.Name;
            OldCustomer.Instagram = customer.Instagram;
            OldCustomer.Facebook = customer.Facebook;
            OldCustomer.Linkedin = customer.Linkedin;
            OldCustomer.Twitter = customer.Twitter;
            OldCustomer.RG = customer.RG;
            OldCustomer.CPF = customer.CPF;
            OldCustomer.BirthDate = customer.BirthDate;
            OldCustomer.Adress = customer.Adress;
            OldCustomer.Phones = customer.Phones;
            _dbContext.Update(OldCustomer);
            _dbContext.SaveChanges();
            
            if (OldCustomer.CPF == customer.CPF)
            {
                return customer;
            } else throw new Exception("não foi possivel atualizar o cadastro.");

        }
    }
}
