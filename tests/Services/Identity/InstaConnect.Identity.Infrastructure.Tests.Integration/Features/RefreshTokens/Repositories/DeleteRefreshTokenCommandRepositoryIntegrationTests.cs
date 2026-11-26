using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class DeleteRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public DeleteRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(RefreshToken, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteRefreshToken_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(RefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}
}
