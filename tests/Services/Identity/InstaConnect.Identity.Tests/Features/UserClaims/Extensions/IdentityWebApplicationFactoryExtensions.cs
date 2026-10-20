using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Helpers;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IUserClaimEventClient CreateClaimEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new UserClaimEventClient(eventClient);
		}
	}
}
