using InstaConnect.Follows.Presentation.Features.Follows.Helpers;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Options;

namespace InstaConnect.Follows.Presentation.Features.Follows.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication MapFollowHub()
		{
			var options = application.Services.GetRequiredService<FollowOptions>();

			application.MapHub<FollowHub>(options.HubRoute);

			return application;
		}
	}
}
