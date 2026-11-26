using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;



namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class DeletePostCommentImageCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public DeletePostCommentImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeletePostCommentImageAsync(
			User,
			Post,
			PostComment,
			PostCommentImage,
			CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentImage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostCommentImage, CancellationToken);
		var postCommentImage = await ServiceScope.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		postCommentImage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostCommentImage, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(PostComment, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}
}
