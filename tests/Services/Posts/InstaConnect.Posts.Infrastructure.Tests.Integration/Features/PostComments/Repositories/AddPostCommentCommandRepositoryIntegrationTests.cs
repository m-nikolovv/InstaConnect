using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;
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
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await base.InitializeAsync();
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
		var cachedPost = await CacheHandler.GetByIdAsync(PostComment, CurrentUserId, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
