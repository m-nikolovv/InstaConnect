using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class AddRangePostCommentImagesCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public AddRangePostCommentImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.DeleteRangeAsync(PostCommentPostCommentImages, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldAddPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.AddRangeAsync(PostCommentPostCommentImages, CancellationToken);
		var postCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentImageIds, CancellationToken);

		// Assert
		postCommentImages.ShouldSatisfy(PostCommentPostCommentImages);
	}
}
