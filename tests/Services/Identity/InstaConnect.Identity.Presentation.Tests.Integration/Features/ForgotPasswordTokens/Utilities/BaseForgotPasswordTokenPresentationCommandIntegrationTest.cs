using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenPresentationCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected ForgotPasswordTokenController Controller { get; }

	protected IForgotPasswordTokenEventClient EventClient { get; }

	protected BaseForgotPasswordTokenPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetForgotPasswordTokenController();
		EventClient = webApplicationFactory.CreateForgotPasswordTokenEventClient();
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
