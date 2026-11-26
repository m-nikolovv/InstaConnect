using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class AddRangePostCommentImagesCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public AddRangePostCommentImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeAddAsync(PostCommentImage, UserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeAddAsync(PostCommentImage, CancellationToken);
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
