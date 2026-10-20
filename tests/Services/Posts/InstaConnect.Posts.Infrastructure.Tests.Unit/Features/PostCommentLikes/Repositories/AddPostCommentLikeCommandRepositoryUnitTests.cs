namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class AddPostCommentLikeCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeCommandRepository _repository;

	public AddPostCommentLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostCommentLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostCommentLike, CancellationToken);
	}
}
