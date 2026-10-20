using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Helpers;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IForgotPasswordTokenEventClient CreateForgotPasswordTokenEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new ForgotPasswordTokenEventClient(eventClient);
		}
	}
}
