using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

using InstaConnect.Common.Domain.Features.AccessTokens.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Abstractions;
using InstaConnect.Common.Presentation.Features.Controllers.Helpers;
using InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromClaim;
using InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromCookie;
using InstaConnect.Common.Presentation.Features.Controllers.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstaConnect.Common.Presentation.Features.Controllers.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddAuthorizationPolicies()
		{
			serviceCollection.AddAuthorizationBuilder()
				.SetDefaultPolicy(new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.RequireClaim(DefaultClaims.Id)
					.Build())
				.AddPolicy(AuthorizationPolicies.Admin, policy => policy.RequireClaim(ApplicationClaims.Admin.GetName()));

			return serviceCollection;
		}

		public IServiceCollection AddApiControllers()
		{
			serviceCollection.AddHttpContextAccessor()
							 .AddScoped<ICookieStore, CookieStore>();

			serviceCollection.AddControllers(options =>
			{
				options.ValueProviderFactories.Add(new FromClaimValueProviderFactory());
				options.ValueProviderFactories.Add(new FromCookieValueProviderFactory());
				options.Conventions.Add(new CamelCaseQueryConvention());
			})
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			})
			.AddControllersAsServices();

			serviceCollection.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressInferBindingSourcesForParameters = true;
				options.SuppressModelStateInvalidFilter = true;
				options.SuppressMapClientErrors = true;
			});

			serviceCollection.AddApiVersioning(options => options.ReportApiVersions = true)
							 .AddMvc();

			return serviceCollection;
		}

		public IServiceCollection AddCorsPolicies(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<CorsOptions>(CorsOptions.SectionName);
			var options = configuration.GetOptions<CorsOptions>(CorsOptions.SectionName);

			serviceCollection.AddCors(o =>
			{
				o.AddPolicy(CorsPolicies.SpecificOrigins, builder =>
					builder.WithOrigins(options.AllowedOrigins.Split(", "))
						   .AllowAnyHeader()
						   .AllowAnyMethod());
			});

			return serviceCollection;
		}

		public IServiceCollection AddRateLimiterPolicies()
		{
			serviceCollection.AddRateLimiter(options =>
			{
				options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

				options.AddPolicy(RateLimiterPolicies.Default,
					httpContext => RateLimitPartition.GetFixedWindowLimiter(
						partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
						factory: _ => new FixedWindowRateLimiterOptions
						{
							PermitLimit = 100,
							Window = TimeSpan.FromSeconds(10),
						}));
			});

			return serviceCollection;
		}
	}
}
