using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_cliente_repository.DTOs
{
    class CustomerDTO
    {

        public string Name { get; init; }

        public DateTime BirthDate { get; init; }

        public string Facebook { get; init; }

        public string Linkedin { get; init; }

        public string Twitter { get; init; }

        public string Instagram { get; init; }

        public List<PhoneNumberDTO> Phones { get; init; }

        public List<AdressDTO> Adress { get; init; }

        public string RG { get; init; }

        public string CPF { get; init; }
    }
}
