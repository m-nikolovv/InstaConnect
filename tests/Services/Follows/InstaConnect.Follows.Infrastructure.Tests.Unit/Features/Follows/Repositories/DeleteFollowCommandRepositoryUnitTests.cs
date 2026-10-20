namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class DeleteFollowCommandRepositoryUnitTests : BaseFollowInfrastructureCommandUnitTest
{
	private readonly FollowCommandRepository _repository;

	public DeleteFollowCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(Follow, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(Follow, CancellationToken);
	}
}
