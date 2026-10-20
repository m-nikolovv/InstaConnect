using InstaConnect.Common.Infrastructure.Features.Telemetries.Models;

using Microsoft.AspNetCore.Hosting;

using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddTelemetries(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
		{
			serviceCollection.AddValidatedOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);
			var options = configuration.GetOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);

			serviceCollection.AddOpenTelemetry()
				  .ConfigureResource(r => r.AddService(webHostEnvironment.ApplicationName))
				  .WithTracing(t => t
					  .AddAspNetCoreInstrumentation()
					  .AddHttpClientInstrumentation()
					  .AddMassTransitInstrumentation()
					  .AddOtlpExporter(o => o.Endpoint = new Uri(options.Endpoint)))
				  .WithMetrics(m => m
					  .AddAspNetCoreInstrumentation()
					  .AddHttpClientInstrumentation()
					  .AddMassTransitInstrumentation()
					  .AddOtlpExporter(o => o.Endpoint = new Uri(options.Endpoint)));

			return serviceCollection;
		}
	}
}
