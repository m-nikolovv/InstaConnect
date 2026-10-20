using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Helpers;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IEmailConfirmationTokenApiClient CreateEmailConfirmationTokenApiClient()
		{
			return new EmailConfirmationTokenApiClient(webApplicationFactory.CreateClient());
		}
	}
}
