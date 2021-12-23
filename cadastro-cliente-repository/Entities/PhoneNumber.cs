using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_cliente_repository.Entities
{
    public class PhoneNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string PhoneType { get; set; }

        public string DDD { get; set; }

        public string PhoneNumbers { get; set; }

        public string? CustomerId { get; set; }
    }
}