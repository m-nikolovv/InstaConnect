using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Repositories;

public class UpdateRefreshTokenCommandRepositoryUnitTests : BaseRefreshTokenInfrastructureCommandUnitTest
{
	private readonly RefreshTokenCommandRepository _repository;

	public UpdateRefreshTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(RefreshToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(RefreshToken, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(RefreshToken, CancellationToken);
	}
}
