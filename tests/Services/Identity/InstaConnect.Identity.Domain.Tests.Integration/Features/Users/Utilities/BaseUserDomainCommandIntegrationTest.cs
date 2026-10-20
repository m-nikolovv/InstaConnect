using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandService Service { get; }

	protected IUserEventClient EventClient { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseUserDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetCommandService();
		EventClient = webApplicationFactory.CreateEventClient();
		EmailConfirmationTokenEventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
