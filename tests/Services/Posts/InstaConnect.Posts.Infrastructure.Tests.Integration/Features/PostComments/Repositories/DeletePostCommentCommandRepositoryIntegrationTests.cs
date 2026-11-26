using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class DeletePostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public DeletePostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(PostComment, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(PostComment, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var postCommentPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentImageIds, CancellationToken);

		// Assert
		postCommentPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var postCommentPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentLikeIds, CancellationToken);

		// Assert
		postCommentPostCommentLikes.ShouldBeEmpty();
	}
}
