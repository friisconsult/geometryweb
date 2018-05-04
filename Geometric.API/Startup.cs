using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Geometric.API
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
            services.AddMvc();

            // setup Swagger
            services.AddSwaggerGen(options =>
            {
                

                options.DescribeAllEnumsAsStrings();
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Geometry services",
                    Description = "This is a showcase, created by Per Friis on request for code show",
                    Contact = new Contact
                    {
                        Email = "per.friis@friisconsult.com",
                        Name = "Per Friis Consult aps",
                        Url = "https://friisconsult.com"
                    },
                    TermsOfService = "This is a completely open services, it has no real purpose other thatn code showcase",
                    Version = "1.0"
                });

                var filePath = PlatformServices.Default.Application.ApplicationBasePath + "Geometric.API.xml";
                options.IncludeXmlComments(filePath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Walk The Talk - Server");
            });

            app.UseMvc();
        }
    }
}
