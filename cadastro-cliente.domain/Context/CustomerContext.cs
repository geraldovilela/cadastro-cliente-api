
using cadastro_cliente_repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace cadastro_cliente.repository.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {
                    
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Address> Adresses { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(a => a.Adress).WithOne();
            modelBuilder.Entity<Customer>().HasMany(p => p.Phones).WithOne();
            modelBuilder.ApplyConfiguration(new CustomerCfg());
            modelBuilder.ApplyConfiguration(new AddressCfg());
            modelBuilder.ApplyConfiguration(new PhoneNumberCfg());
        }
    }
}
