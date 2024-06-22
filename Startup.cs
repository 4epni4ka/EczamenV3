using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title="������� GET",
                    Description="������� GET"
                });
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "������� POST",
                    Description = "������� POST"
                });
                c.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v3",
                    Title = "������� PUT",
                    Description = "������� PUT"
                });
                c.SwaggerDoc("v4", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v4",
                    Title = "������� DELETE",
                    Description = "������� DELETE"
                });
                string path = Path.Combine(AppContext.BaseDirectory, "EczamenV3.xml");
                c.IncludeXmlComments(path);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� GET");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� POST");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� PUT");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� DELETE");
            });
        }

    }
}
