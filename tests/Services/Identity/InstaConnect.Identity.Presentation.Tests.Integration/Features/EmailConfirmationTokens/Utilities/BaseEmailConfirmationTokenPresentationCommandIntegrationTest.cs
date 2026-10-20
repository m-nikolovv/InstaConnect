using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenPresentationCommandIntegrationTest : BaseEmailConfirmationTokenWebTest
{
	protected EmailConfirmationTokenController Controller { get; }

	protected IEmailConfirmationTokenEventClient EventClient { get; }

	protected BaseEmailConfirmationTokenPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetEmailConfirmationTokenController();
		EventClient = webApplicationFactory.CreateEmailConfirmationTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
