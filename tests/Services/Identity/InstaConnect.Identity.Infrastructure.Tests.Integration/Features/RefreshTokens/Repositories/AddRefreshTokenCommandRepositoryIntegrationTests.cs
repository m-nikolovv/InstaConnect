using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class AddRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public AddRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddAsync_ShouldAddRefreshToken_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(RefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(RefreshToken);
	}
}
