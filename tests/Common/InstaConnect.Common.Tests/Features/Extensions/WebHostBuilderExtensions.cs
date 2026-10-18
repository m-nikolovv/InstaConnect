using InstaConnect.Common.Infrastructure.Features.AccessTokens.Models;
using InstaConnect.Common.Infrastructure.Features.Caches.Models;
using InstaConnect.Common.Infrastructure.Features.Analyzers.Models;
using InstaConnect.Common.Infrastructure.Features.Databases.Models;
using InstaConnect.Common.Infrastructure.Features.Emails.Models;
using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Common.Infrastructure.Features.Images.Models;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Models;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Models;
using InstaConnect.Common.Tests.Features.Utilities;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class WebHostBuilderExtensions
{
	extension(IWebHostBuilder webHostBuilder)
	{
		public void UpdateMongoConfiguration(string connectionString)
		{
			webHostBuilder.UseSetting(
				MongoOptions.SectionName.ToSectionKey(nameof(MongoOptions.ConnectionString)),
				connectionString);

			webHostBuilder.UseSetting(MongoOptions.SectionName.ToSectionKey(nameof(MongoOptions.Name)),
				MockValues.MongoName);
		}

		public void UpdateRedisConfiguration(string connectionString)
		{
			webHostBuilder.UseSetting(
				RedisOptions.SectionName.ToSectionKey(nameof(RedisOptions.ConnectionString)),
				connectionString);
		}

		public void UpdateRabbitMqConfiguration(string connectionString)
		{
			webHostBuilder.UseSetting(
				RabbitMqOptions.SectionName.ToSectionKey(nameof(RabbitMqOptions.ConnectionString)),
				connectionString);
		}

		public void UpdateCloudinaryConfiguration()
		{
			webHostBuilder.UseSetting(
				CloudinaryOptions.SectionName.ToSectionKey(nameof(CloudinaryOptions.CloudName)),
				MockValues.CloudinaryCloudName);

			webHostBuilder.UseSetting(
				CloudinaryOptions.SectionName.ToSectionKey(nameof(CloudinaryOptions.ApiKey)),
				MockValues.CloudinaryApiKey);

			webHostBuilder.UseSetting(
				CloudinaryOptions.SectionName.ToSectionKey(nameof(CloudinaryOptions.ApiSecret)),
				MockValues.CloudinaryApiSecret);
		}

		public void UpdateOpenAiConfiguration()
		{
			webHostBuilder.UseSetting(
				OpenAiOptions.SectionName.ToSectionKey(nameof(OpenAiOptions.ApiKey)),
				MockValues.OpenAiApiKey);

			webHostBuilder.UseSetting(
				OpenAiOptions.SectionName.ToSectionKey(nameof(OpenAiOptions.Model)),
				MockValues.OpenAiModel);
		}

		public void UpdateSendGridConfiguration()
		{
			webHostBuilder.UseSetting(
				SendGridOptions.SectionName.ToSectionKey(nameof(SendGridOptions.Sender)),
				MockValues.SendGridSender);

			webHostBuilder.UseSetting(
				SendGridOptions.SectionName.ToSectionKey(nameof(SendGridOptions.ApiKey)),
				MockValues.SendGridApiKey);
		}

		public void UpdateAccessTokenConfiguration()
		{
			webHostBuilder.UseSetting(
				AccessTokenOptions.SectionName.ToSectionKey(nameof(AccessTokenOptions.SecurityKey)),
				MockValues.AccessTokenSecurityKey);

			webHostBuilder.UseSetting(
				AccessTokenOptions.SectionName.ToSectionKey(nameof(AccessTokenOptions.Issuer)),
				MockValues.AccessTokenIssuer);

			webHostBuilder.UseSetting(
				AccessTokenOptions.SectionName.ToSectionKey(nameof(AccessTokenOptions.Audience)),
				MockValues.AccessTokenAudience);
		}

		public void UpdateOpenTelemetryConfiguration()
		{
			webHostBuilder.UseSetting(
				OpenTelemetryOptions.SectionName.ToSectionKey(nameof(OpenTelemetryOptions.Endpoint)),
				MockValues.OpenTelemetryEndpoint);
		}

		public void UpdateCorsConfiguration()
		{
			webHostBuilder.UseSetting(
				CorsOptions.SectionName.ToSectionKey(nameof(CorsOptions.AllowedOrigins)),
				MockValues.CorsAllowedOrigins);
		}

		public void UpdateMainConfiguration()
		{
			webHostBuilder.UseSetting(
				MainOptions.SectionName.ToSectionKey(nameof(MainOptions.BaseUrl)),
				MockValues.MainBaseUrl);
		}
	}
}
