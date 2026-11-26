namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class DeleteUserCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public DeleteUserCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(User, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(User, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(User, CancellationToken);
	}
}
