using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class AddUserClaimCommandRepositoryIntegrationTests : BaseUserClaimInfrastructureCommandIntegrationTest
{
	public AddUserClaimCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeAddAsync(UserClaim, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeAddAsync(UserClaim, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUserClaim_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(UserClaim, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaimId, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(UserClaim);
	}
}
