
using System.Text;
using laptop_rental.Application.Customers.Services;
using laptop_rental.Application.Customers.Services.Interfaces;
using laptop_rental.Application.Laptops.Services;
using laptop_rental.Application.Laptops.Services.Interfaces;
using laptop_rental.Application.Rents.Services;
using laptop_rental.Application.Rents.Services.Interfaces;
using laptop_rental.Domain;
using laptop_rental.Domain.Customers.Services;
using laptop_rental.Infraestructure.Contexts;
using laptop_rental.Infraestructure.Customers;
using laptop_rental.Infraestructure.Laptops;
using laptop_rental.Infraestructure.Rents;
using laptop_rental.laptop_rental.Domain.RentItems.Services;
using laptop_rental.laptop_rental.Domain.RentItems.Services.Interfaces;
using laptop_rental.laptop_rental.Domain.Rents.Services;
using laptop_rental.laptop_rental.Domain.Rents.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace laptop_rental
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Options:Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCors();
            services.AddDbContext<DataContext>(opt => { opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")); }, ServiceLifetime.Transient);
            services.AddScoped<ILaptopRepository, LaptopRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IFindLaptopByBrandService, FindLaptopByBrandService>();
            services.AddTransient<ICustomerLoginService, CustomerLoginService>();
            services.AddTransient<ICreateRentService, CreateRentService>();
            services.AddTransient<ISimulateRentService, SimulateRentService>();
            services.AddTransient<IRefundRentService, RefundRentService>();
            services.AddTransient<ILaptopService, LaptopService>();
            services.AddTransient<IRentService, RentService>();
            services.AddTransient<IValidateItemStock, ValidateItemStock>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IGenerateTokenService, GenerateTokenService>();
            services.AddMvc();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(opt =>
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("Options"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());



            app.UseRouting();

            app.UseAuthorization();
            app.UseHttpsRedirection();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

