using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(User, UserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(User, CurrentUserId, CancellationToken);

		// Assert
		cachedUser.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPosts_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostComments_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostComments_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}
}
