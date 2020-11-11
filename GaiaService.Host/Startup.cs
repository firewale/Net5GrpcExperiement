using Autofac;
using Autofac.Extensions.DependencyInjection;
using GaiaService.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net5GrpcExperiement
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; private set; }

		public ILifetimeScope AutofacContainer { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddGrpc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// If, for some reason, you need a reference to the built container, you
			// can use the convenience extension method GetAutofacRoot.
			AutofacContainer = app.ApplicationServices.GetAutofacRoot();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<GaiaService>();

				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
				});
			});
		}

		// ConfigureContainer is where you can register things directly
		// with Autofac. This runs after ConfigureServices so the things
		// here will override registrations made in ConfigureServices.
		// Don't build the container; that gets done for you by the factory.
		public void ConfigureContainer(ContainerBuilder builder)
		{
			// Register your own things directly with Autofac here. Don't
			// call builder.Populate(), that happens in AutofacServiceProviderFactory
			// for you.
			builder.RegisterModule(new GaiaAutofacModule());
		}
	}
}
