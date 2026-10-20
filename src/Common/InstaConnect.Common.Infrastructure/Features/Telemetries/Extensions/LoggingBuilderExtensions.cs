using InstaConnect.Common.Infrastructure.Features.Telemetries.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

namespace InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;

public static class LoggingBuilderExtensions
{
	extension(ILoggingBuilder loggingBuilder)
	{
		public ILoggingBuilder AddTelemetries(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
		{
			var openTelemetryOptions = configuration.GetOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);

			var resourceBuilder = ResourceBuilder.CreateDefault().AddService(webHostEnvironment.ApplicationName);

			loggingBuilder.AddOpenTelemetry(options =>
			{
				options.SetResourceBuilder(resourceBuilder);
				options.AddOtlpExporter(options =>
				{
					options.Endpoint = new Uri(openTelemetryOptions.Endpoint);
				});
			});

			return loggingBuilder;
		}
	}
}
