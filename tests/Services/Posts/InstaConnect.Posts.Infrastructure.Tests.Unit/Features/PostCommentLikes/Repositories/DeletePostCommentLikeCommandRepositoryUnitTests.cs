namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class DeletePostCommentLikeCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeCommandRepository _repository;

	public DeletePostCommentLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostCommentLike, CancellationToken);
	}
}
