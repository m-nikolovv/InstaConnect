using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureQueryIntegrationTest : BaseUserClaimWebTest
{
	protected IUserClaimQueryRepository Repository { get; }

	protected BaseUserClaimInfrastructureQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetClaimQueryRepository();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await OnInitializeAsync();
	}
}
