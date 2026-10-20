using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Helpers;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IUserClaimApiClient CreateClaimApiClient()
		{
			return new UserClaimApiClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
