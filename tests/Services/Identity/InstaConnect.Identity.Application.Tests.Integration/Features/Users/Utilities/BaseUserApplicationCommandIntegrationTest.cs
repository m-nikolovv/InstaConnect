using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandIntegrationTest : BaseUserWebTest
{
	protected IApplicationSender Sender { get; }

	protected IUserEventClient EventClient { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseUserApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
