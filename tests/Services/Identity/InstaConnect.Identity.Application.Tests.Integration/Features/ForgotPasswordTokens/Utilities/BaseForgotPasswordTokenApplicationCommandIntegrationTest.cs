using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenApplicationCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IApplicationSender Sender { get; }

	protected IForgotPasswordTokenEventClient ForgotPasswordTokenEventClient { get; }

	protected BaseForgotPasswordTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		ForgotPasswordTokenEventClient = webApplicationFactory.CreateForgotPasswordTokenEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
		await ForgotPasswordTokenEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ForgotPasswordTokenEventClient.StopAsync(CancellationToken);
	}
}
