﻿using AutoMapper;
using cadastro_cliente.repository.Interfaces;
using cadastro_cliente_facades.Interfaces;
using cadastro_cliente_repository.DTOs;
using cadastro_cliente_repository.Entities;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cadastro_cliente_facades
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;


        public CustomerFacade(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomer(CustomerDTO data)
        {

            data.CPF = ClearString(data.CPF);
            data.RG = ClearString(data.RG);
            if (!ValidateCpf(data.CPF))
            {
                throw new Exception("CPF Invalido.");
            }
            var customer = _mapper.Map<Customer>(data);

            var CustomerRegistry = await _customerRepository.SaveCustomer(customer);


            return CustomerRegistry;
        }

        public Task DeleteCustomer(CustomerDTO data)
        {
            throw new NotImplementedException();
        }

        public static string ClearString(string s)
        {
            var regEx = new Regex("[^0-9a-zA-Z]+");
            return regEx.Replace(s,"");
        }

        public static bool ValidateCpf(string CPF)
        {
            if (CPF.Length == 11)
            {
                return true;
            }else return false;
            ;
        }
    }
}