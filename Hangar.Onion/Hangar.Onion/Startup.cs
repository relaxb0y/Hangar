using Hangar.Core.Hangar;
using Hangar.Core.Plane;
using Hangar.Data;
using Hangar.Data.Hangar;
using Hangar.Data.Plane;
using Hangar.Orchestrators.Hangar;
using Hangar.Orchestrators.Plane;
using Hangar.Orchestrators.Plane.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Hangar.Onion
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
            string connString = Configuration.GetConnectionString("HangarDB");
            services.AddDbContext<HangarContext>(options => options.UseSqlServer(connString));
            services.AddAutoMapper(typeof(HangarProfile));
            services.AddAutoMapper(typeof(AirCraftProfile));
            
            services.AddScoped<IHangarRepository, HangarRepository>();
            services.AddScoped<IHangarService, HangarService>();
            
            services.AddScoped<IPlaneRepository, AirCraftRepository>();
            services.AddScoped<IPlaneService, AirCraftService>();
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Hangar", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hangar v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}