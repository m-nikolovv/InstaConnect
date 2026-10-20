using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenApplicationCommandIntegrationTest : BaseEmailConfirmationTokenWebTest
{
	protected IApplicationSender Sender { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseEmailConfirmationTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		EmailConfirmationTokenEventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
		await EmailConfirmationTokenEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EmailConfirmationTokenEventClient.StopAsync(CancellationToken);
	}
}
