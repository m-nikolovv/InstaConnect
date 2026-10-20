using HealthChecks.UI.Client;

using InstaConnect.Common.Presentation.Features.Controllers.Utilities;

namespace InstaConnect.Common.Presentation.Features.Controllers.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication webApplication)
	{
		public WebApplication UseCorsPolicies()
		{
			webApplication.UseCors(CorsPolicies.SpecificOrigins);

			return webApplication;
		}

		public WebApplication UseRateLimiterPolicies()
		{
			webApplication.UseRateLimiter();

			return webApplication;
		}

		public WebApplication MapApiControllers()
		{
			webApplication.MapControllers();

			return webApplication;
		}

		public WebApplication MapHealthCheckEndpoints()
		{
			const string HealthCheckEndpoint = "/healthz";

			webApplication.MapHealthChecks(HealthCheckEndpoint, new()
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

			return webApplication;
		}
	}
}
