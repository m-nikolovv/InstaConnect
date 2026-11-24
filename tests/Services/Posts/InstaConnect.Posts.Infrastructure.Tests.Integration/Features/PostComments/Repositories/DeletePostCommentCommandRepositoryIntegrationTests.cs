using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class DeletePostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public DeletePostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostComment, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CurrentUserId, CancellationToken);
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
		var cachedPostComment = await CommentCacheHandler.GetByIdAsync(PostComment, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var cachedPost = await CacheHandler.GetByIdAsync(PostComment, CancellationToken);

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
