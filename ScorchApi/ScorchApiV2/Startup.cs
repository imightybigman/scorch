using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using ScorchApiV2.Middleware;
using System;
using System.Collections.Generic;

namespace ScorchApiV2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{GetEnvVariableAWSBeansTalkHack(env)}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private static string GetEnvVariableAWSBeansTalkHack(IHostingEnvironment env)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration", optional: true, reloadOnChange: true).Build();

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (IConfigurationSection pair in config.GetSection("iis:env").GetChildren())
            {
                string[] keypair = pair.Value.Split(new[] { '=' }, 2);
                dict.Add(keypair[0], keypair[1]);
            }

            return dict.ContainsKey("ASPNETCORE_ENVIRONMENT")
                ? dict["ASPNETCORE_ENVIRONMENT"]
                : env.EnvironmentName;
        }

        public IConfigurationRoot Configuration { get; }
         
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // Add framework services.
            services.AddMvc()
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            var dynamoTables = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(dynamoTables);


            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Scorch API", Version = "v2" });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "ScorchApi.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scorch API V1");
            });
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMvc();

        }
    }
}
