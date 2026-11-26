using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class DeleteUserClaimCommandRepositoryIntegrationTests : BaseUserClaimInfrastructureCommandIntegrationTest
{
	public DeleteUserClaimCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteUserClaimAsync(User, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserClaim_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(UserClaim, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaimId, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedUserClaim_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(UserClaim, CancellationToken);
		var cachedUserClaim = await ServiceScope.GetUserClaimCacheByIdAsync(UserClaim, CancellationToken);

		// Assert
		cachedUserClaim.ShouldBeNull();
	}
}
