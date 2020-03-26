using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebappsIV_1920_be_AudreyB.Data;
using WebappsIV_1920_be_AudreyB.Data.Repository;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB
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
            services.AddControllers();
           // services.AddSwaggerDocument();
            services.AddOpenApiDocument(s =>
            {
                s.DocumentName = "APIdocs";
                s.Title = "Film API";
                s.Version = "v1";
                s.Description = "De documentatie van de film API";
            });
            services.AddDbContext<FilmContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FilmContext")));
            
            services.AddScoped<FilmDataInitializer>();
            services.AddScoped<IFilmRepository, FilmRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env /*FilmDataInitializer filmDataInitializer*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //filmDataInitializer.InitializeData();
        }
    }
}
