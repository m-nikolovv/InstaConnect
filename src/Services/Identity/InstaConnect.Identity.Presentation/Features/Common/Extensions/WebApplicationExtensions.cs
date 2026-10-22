using InstaConnect.Common.Presentation.Features.AccessTokens.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;

namespace InstaConnect.Identity.Presentation.Features.Common.Extensions;

internal static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication UsePresentation()
		{
			return application
				.UseCorsPolicies()
				.UseRateLimiterPolicies()
				.UseAccessTokens()
				.MapApiControllers()
				.UseExceptions()
				.MapHealthCheckEndpoints();
		}
	}
}
