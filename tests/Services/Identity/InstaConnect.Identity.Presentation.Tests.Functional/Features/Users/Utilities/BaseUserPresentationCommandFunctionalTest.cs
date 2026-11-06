using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandFunctionalTest : BaseIdentityWebCommandTest
{
	protected IUserApiClient ApiClient { get; }

	protected IUserEventClient EventClient { get; }

	protected IEmailConfirmationTokenEventClient EmailConfirmationTokenEventClient { get; }

	protected BaseUserPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateApiClient();
		EventClient = webApplicationFactory.CreateEventClient();
		EmailConfirmationTokenEventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
