using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class AddPostCommentImageCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public AddPostCommentImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentImage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostCommentImage, CancellationToken);
		var postCommentImage = await ServiceScope.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		postCommentImage.ShouldSatisfy(PostCommentImage);
	}
}
