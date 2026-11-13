using InstaConnect.Common.Presentation.Features.AccessTokens.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Databases.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;

namespace InstaConnect.Follows.Presentation.Features.Common.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication UsePresentation()
		{
			return application
				.UseForwardedHeaderPolicies()
				.UseExceptions()
				.UseCorsPolicies()
				.UseAccessTokens()
				.UseRateLimiterPolicies()
				.MapApiControllers()
				.MapHealthCheckEndpoints()
				.MapFollowHub();
		}

		public async Task RunPresentationAsync(CancellationToken cancellationToken)
		{
			await application.UseDatabaseInitializerAsync(cancellationToken);

			await application.StartAsync(cancellationToken);

			await application.UseDatabaseSeederAsync(cancellationToken);

			await application.WaitForShutdownAsync(cancellationToken);
		}
	}
}
