namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UpdateUserCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public UpdateUserCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(User, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(User, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(User, CancellationToken);
	}
}
