using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Repositories;

public class DeleteRefreshTokenCommandRepositoryUnitTests : BaseRefreshTokenInfrastructureCommandUnitTest
{
	private readonly RefreshTokenCommandRepository _repository;

	public DeleteRefreshTokenCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(RefreshToken, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(RefreshToken, CancellationToken);
	}
}
