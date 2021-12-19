using AutoMapper;
using cadastro_cliente.repository;
using cadastro_cliente.repository.Context;
using cadastro_cliente.repository.Interfaces;
using cadastro_cliente_facades;
using cadastro_cliente_facades.Interfaces;
using cadastro_cliente_repository.DTOs;
using cadastro_cliente_repository.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace cadastro_cliente_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Address, AdressDTO>();
                cfg.CreateMap<AdressDTO, Address>();
                cfg.CreateMap<PhoneNumber, PhoneNumberDTO>();
                cfg.CreateMap<PhoneNumberDTO, PhoneNumber>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddDbContextPool<CustomerContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("CustomerConnection")
                ));
            services.AddSingleton<CustomerContext>();

            services.AddSingleton(mapper);
            services.AddSingleton<ICustomerFacade, CustomerFacade>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "cadastro_cliente_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "cadastro_cliente_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
