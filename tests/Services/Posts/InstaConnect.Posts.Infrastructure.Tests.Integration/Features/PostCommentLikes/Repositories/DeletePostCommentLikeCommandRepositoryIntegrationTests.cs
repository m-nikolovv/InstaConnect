using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class DeletePostCommentLikeCommandRepositoryIntegrationTests : BasePostCommentLikeInfrastructureCommandIntegrationTest
{
	public DeletePostCommentLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(PostCommentLike, UserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostCommentLike, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostCommentLike, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(PostCommentLike, CurrentUserId, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostCommentLike, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(PostCommentLike, CurrentUserId, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}
}
