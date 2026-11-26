using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class AddPostCommentLikeCommandRepositoryIntegrationTests : BasePostCommentLikeInfrastructureCommandIntegrationTest
{
	public AddPostCommentLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeAddAsync(PostCommentLike, UserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeAddAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostCommentLike, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(PostCommentLike);
	}

	[Fact]
	public async Task AddAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostCommentLike, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(PostCommentLike, CurrentUserId, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}
}
