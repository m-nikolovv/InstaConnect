using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Helpers;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IRefreshTokenApiClient CreateRefreshTokenApiClient()
		{
			return new RefreshTokenApiClient(webApplicationFactory.CreateClient());
		}
	}
}
