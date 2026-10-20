using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest : BaseEmailConfirmationTokenWebTest
{
	protected IEmailConfirmationTokenCommandRepository Repository { get; }

	protected IEmailConfirmationTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetEmailConfirmationTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetEmailConfirmationTokenIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
	}
}
