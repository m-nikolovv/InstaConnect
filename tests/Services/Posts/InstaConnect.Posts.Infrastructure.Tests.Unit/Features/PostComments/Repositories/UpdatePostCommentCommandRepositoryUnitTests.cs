namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class UpdatePostCommentCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public UpdatePostCommentCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(PostComment, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(PostComment, CancellationToken);
	}
}
