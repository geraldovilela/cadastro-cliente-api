using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_cliente_repository.DTOs
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Facebook { get; set; }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public List<PhoneNumberDTO> Phones { get; set; }

        public List<AdressDTO> Adress { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }
    }
}
