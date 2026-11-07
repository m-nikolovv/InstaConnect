using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class AddUserClaimCommandRepositoryIntegrationTests : BaseUserClaimInfrastructureCommandIntegrationTest
{
	public AddUserClaimCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
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
