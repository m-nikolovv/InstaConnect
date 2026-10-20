using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandIntegrationTest : BaseUserWebTest
{
	protected UserController Controller { get; }

	protected IUserEventClient EventClient { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseUserPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserController();
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
