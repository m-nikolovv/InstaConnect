using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenPresentationCommandFunctionalTest : BaseIdentityWebCommandTest
{
	protected IForgotPasswordTokenApiClient ForgotPasswordTokenApiClient { get; }

	protected IForgotPasswordTokenEventClient ForgotPasswordTokenEventClient { get; }

	protected BaseForgotPasswordTokenPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ForgotPasswordTokenApiClient = webApplicationFactory.CreateForgotPasswordTokenApiClient();
		ForgotPasswordTokenEventClient = webApplicationFactory.CreateForgotPasswordTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ForgotPasswordTokenEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ForgotPasswordTokenEventClient.StopAsync(CancellationToken);
	}
}
