using InstaConnect.Posts.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class AddPostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public AddPostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeAddAsync(PostComment, UserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeAddAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(PostComment);
	}

	[Fact]
	public async Task AddAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostComment, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(PostComment, UserId, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
