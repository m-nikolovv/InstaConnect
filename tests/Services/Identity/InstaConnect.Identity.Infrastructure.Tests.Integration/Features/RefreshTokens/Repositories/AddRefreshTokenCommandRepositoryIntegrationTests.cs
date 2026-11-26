using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class AddRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public AddRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeAddAsync(RefreshToken, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeAddAsync(RefreshToken, CancellationToken);
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
