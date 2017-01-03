using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Abc.Service.Services;
using Abc.Dal.Models;
using Abc.Dal.Repository;
using Abc.Dal.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Newtonsoft;
using AutoMapper;
using Abc.Api.Mappings;

namespace Abc.Api
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
			
			builder.AddEnvironmentVariables();
			Configuration = builder.Build();

			_mapperConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperConfiguration());
			});
		}
		public IConfigurationRoot Configuration { get; }
		private MapperConfiguration _mapperConfiguration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Repositories
			services.AddSingleton(typeof(DatabaseContext));
			services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));			
			services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));			
			services.AddSingleton(typeof(IEntityService<>), typeof(EntityService<>));
			services.AddSingleton(typeof(IAccountService), typeof(AccountService));
			services.AddTransient(typeof(IAbsenceService), typeof(AbsenceService));
			//automapper
			services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
			
			// Add MVC services to the services container.
			services.AddMvc();

			// Inject an implementation of ISwaggerProvider with defaulted settings applied
			services.AddSwaggerGen();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc(routes =>
			{
				routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
				routes.MapRoute("api", "api/" + "{controller=Account}/{action=Login}");
			});

			// Enable middleware to serve generated Swagger as a JSON endpoint
			app.UseSwagger();

			// Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
			app.UseSwaggerUi();
		}
	}
}
