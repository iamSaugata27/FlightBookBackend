using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBook.Context;
using FlightBook.Data;
using FlightBook.Services.AirportDetail;
using FlightBook.Services.FlightCreationService;
using FlightBook.Services.PassengerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlightBook
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
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationDBContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddSingleton<DapperContext>();

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(mySqlConnectionStr));
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IFlightServc, FlightServc>();
            services.AddScoped<IAirportServc, AirportServc>();
            services.AddScoped<IPassengerServc, PassengerServc>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
