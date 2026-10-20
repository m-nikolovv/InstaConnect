namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class DeletePostCommentCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public DeletePostCommentCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostComment, CancellationToken);
	}
}
