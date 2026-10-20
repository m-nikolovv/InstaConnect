namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class DeletePostLikeCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeCommandRepository _repository;

	public DeletePostLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostLike, CancellationToken);
	}
}
