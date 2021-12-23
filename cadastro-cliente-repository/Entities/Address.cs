using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_cliente_repository.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string Addresses { get; set; }

        public string AddressType { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}