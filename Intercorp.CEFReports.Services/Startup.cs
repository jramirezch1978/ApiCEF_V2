using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Intercorp.CEFReports.Transversal.Mapper;
using Intercorp.CEFReports.Transversal.Common;
using Intercorp.CEFReports.Infrastructure.Data;
using Intercorp.CEFReports.Application.Interface;
using Intercorp.CEFReports.Application.Main;
using Intercorp.CEFReports.Domain.Interface;
using Intercorp.CEFReports.Domain.Core;
using Intercorp.CEFReports.Infrastructure.Interface;
using Intercorp.CEFReports.Infrastructure.Repository;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Intercorp.CEFReports.Middlewares.Option;
using System.IO;

namespace Intercorp.CEFReports.Services
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var MappingConf = new MapperConfiguration(x => x.AddProfile(new MappingsProfile()));
            IMapper mapper = MappingConf.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, builder => builder
                 .WithOrigins("http://localhost:8089")
                 .AllowAnyHeader()
                 .AllowAnyMethod())
           );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IClientApplication, ClientApplication>();
            services.AddScoped<IClientDomain, ClientDomain>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IProyeccionApplication, ProyeccionApplication>();
            services.AddScoped<IProyeccionDomain, ProyeccionDomain>();
            services.AddScoped<IProyeccionRepository, ProyeccionRepository>();

            services.AddScoped<IReconciliacionPatrimonioApplication, ReconciliacionPatrimonioApplication>();
            services.AddScoped<IReconciliacionPatrimonioDomain, ReconciliacionPatrimonioDomain>();
            services.AddScoped<IReconciliacionPatrimonioRepository, ReconciliacionPatrimonioRepository>();

            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOptions();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // setup app's root folders
            AppDomain.CurrentDomain.SetData("ContentRootPath", env.ContentRootPath);
            AppDomain.CurrentDomain.SetData("WebRootPath", env.WebRootPath);
        }

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(SettingsJson, optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public String SettingsJson { get; set; }
    }
}
