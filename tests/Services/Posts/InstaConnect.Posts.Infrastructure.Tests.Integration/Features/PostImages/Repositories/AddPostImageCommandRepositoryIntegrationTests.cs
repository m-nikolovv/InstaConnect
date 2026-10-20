using InstaConnect.Posts.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class AddPostImageCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public AddPostImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostImage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostImage, CancellationToken);
		var postImage = await ServiceScope.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		postImage.ShouldSatisfy(PostImage);
	}
}
