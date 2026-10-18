using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class DeletePostCommentImageCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public DeletePostCommentImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostCommentImage, CancellationToken);
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
}
