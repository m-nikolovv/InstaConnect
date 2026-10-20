using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Helpers;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IForgotPasswordTokenApiClient CreateForgotPasswordTokenApiClient()
		{
			return new ForgotPasswordTokenApiClient(webApplicationFactory.CreateClient());
		}
	}
}
