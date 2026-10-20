using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class AddRangePostCommentImagesCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public AddRangePostCommentImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddRangeAsync_ShouldAddPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.AddRangeAsync(PostCommentImages, CancellationToken);
		var postCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentImageIds, CancellationToken);

		// Assert
		postCommentImages.ShouldSatisfy(PostCommentImages);
	}
}
