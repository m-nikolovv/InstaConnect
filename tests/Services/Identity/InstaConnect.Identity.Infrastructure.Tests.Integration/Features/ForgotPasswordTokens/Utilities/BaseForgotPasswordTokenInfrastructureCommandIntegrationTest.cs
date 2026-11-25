using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenInfrastructureCommandIntegrationTest : BaseForgotPasswordTokenWebCommandTest
{
	protected IForgotPasswordTokenCommandRepository Repository { get; }

	protected IForgotPasswordTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseForgotPasswordTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetForgotPasswordTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetForgotPasswordTokenIncludeBuilderFactory();
	}
}
