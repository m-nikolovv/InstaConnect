using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenApplicationMockFactory
{
	public static IEmailConfirmationTokenCommandService CreateCommandService()
	{
		return Mocker.Mock<IEmailConfirmationTokenCommandService>();
	}
}
