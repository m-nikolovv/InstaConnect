using InstaConnect.Common.Presentation.Features.AccessTokens.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;

namespace InstaConnect.Posts.Presentation.Features.Common.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication UsePresentation()
		{
			return application
				.UseCorsPolicies()
				.UseAccessTokens()
				.UseRateLimiterPolicies()
				.MapApiControllers()
				.UseExceptions()
				.MapHealthCheckEndpoints();
		}
	}
}
