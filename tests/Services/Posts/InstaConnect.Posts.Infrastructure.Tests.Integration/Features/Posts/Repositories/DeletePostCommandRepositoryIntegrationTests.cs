namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class DeletePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public DeletePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postCommentLikes.ShouldBeEmpty();
	}
}
