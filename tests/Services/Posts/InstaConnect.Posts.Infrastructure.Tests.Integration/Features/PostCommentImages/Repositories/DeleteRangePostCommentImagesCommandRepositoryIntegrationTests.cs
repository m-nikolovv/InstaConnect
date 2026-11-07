namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class DeleteRangePostCommentImagesCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public DeleteRangePostCommentImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldDeletePostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteRangeAsync(PostCommentImages, CancellationToken);
		var postCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentImageIds, CancellationToken);

		// Assert
		postCommentImages.ShouldBeEmpty();
	}
}
