using InstaConnect.Follows.Presentation.Features.Follows.Models.Options;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Follows.Tests.Features.Common.Extensions;

public static class WebHostBuilderExtensions
{
	extension(IWebHostBuilder webHostBuilder)
	{
		public void UpdateFollowConfiguration()
		{
			webHostBuilder.UseSetting(
				FollowOptions.SectionName.ToSectionKey(nameof(FollowOptions.HubRoute)),
				FollowsMockValues.FollowHubRoute);
		}
	}
}
