using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenInfrastructureCommandIntegrationTest : BaseRefreshTokenWebTest
{
	protected IRefreshTokenCommandRepository Repository { get; }

	protected IRefreshTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseRefreshTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetRefreshTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetRefreshTokenIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		await OnInitializeAsync();
	}
}
