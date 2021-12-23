using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_cliente_repository.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Facebook { get; set; }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public ICollection<PhoneNumber> Phones { get; set; }

        public ICollection<Address> Adress { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }
    };
}
