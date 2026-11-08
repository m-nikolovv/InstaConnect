using InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;
using InstaConnect.Common.Presentation.Features.AccessTokens.Extensions;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Databases.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;

namespace InstaConnect.Chats.Presentation.Features.Common.Extensions;

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
				.MapHealthCheckEndpoints()
				.MapChatMessageHub();
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
