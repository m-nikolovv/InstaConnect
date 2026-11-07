namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class DeletePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public DeletePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
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
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

}
