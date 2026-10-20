namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class DeletePostCommandRepositoryUnitTests : BasePostInfrastructureCommandUnitTest
{
	private readonly PostCommandRepository _repository;

	public DeletePostCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(Post, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(Post, CancellationToken);
	}
}
