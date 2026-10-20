using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenInfrastructureCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenCommandRepository Repository { get; }

	protected IForgotPasswordTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseForgotPasswordTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetForgotPasswordTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetForgotPasswordTokenIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
	}
}
