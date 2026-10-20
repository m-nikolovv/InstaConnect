namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class AddPostCommentCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public AddPostCommentCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostComment, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostComment, CancellationToken);
	}
}
