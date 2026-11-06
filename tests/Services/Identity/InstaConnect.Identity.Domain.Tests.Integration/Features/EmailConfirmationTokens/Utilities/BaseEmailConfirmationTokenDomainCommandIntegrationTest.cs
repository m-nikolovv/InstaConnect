using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenDomainCommandIntegrationTest : BaseIdentityWebCommandTest
{
	protected IEmailConfirmationTokenCommandService Service { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseEmailConfirmationTokenDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory, isEmailConfirmed: false)
	{
		Service = ServiceScope.GetEmailConfirmationTokenCommandService();
		EmailConfirmationTokenEventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await EmailConfirmationTokenEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EmailConfirmationTokenEventClient.StopAsync(CancellationToken);
	}
}
