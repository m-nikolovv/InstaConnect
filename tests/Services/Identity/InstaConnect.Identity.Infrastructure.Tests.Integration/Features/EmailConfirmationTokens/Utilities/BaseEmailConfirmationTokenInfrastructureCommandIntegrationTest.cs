using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest : BaseIdentityWebCommandTest
{
	protected IEmailConfirmationTokenCommandRepository Repository { get; }

	protected IEmailConfirmationTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory, isEmailConfirmed: false)
	{
		Repository = ServiceScope.GetEmailConfirmationTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetEmailConfirmationTokenIncludeBuilderFactory();
	}
}
