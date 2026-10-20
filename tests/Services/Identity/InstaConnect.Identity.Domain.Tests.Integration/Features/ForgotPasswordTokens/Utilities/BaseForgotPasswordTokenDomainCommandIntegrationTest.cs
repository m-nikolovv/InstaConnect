using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenDomainCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenCommandService Service { get; }

	protected IForgotPasswordTokenEventClient ForgotPasswordTokenEventClient { get; }

	protected BaseForgotPasswordTokenDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetForgotPasswordTokenCommandService();
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
