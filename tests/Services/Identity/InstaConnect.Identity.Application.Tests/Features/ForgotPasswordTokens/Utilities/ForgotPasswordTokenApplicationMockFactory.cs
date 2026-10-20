using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenApplicationMockFactory
{
	public static IForgotPasswordTokenCommandService CreateCommandService()
	{
		return Mocker.Mock<IForgotPasswordTokenCommandService>();
	}
}
