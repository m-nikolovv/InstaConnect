using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class DeletePostImageCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public DeletePostImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostImage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostImage, CancellationToken);
		var postImage = await ServiceScope.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		postImage.ShouldBeNull();
	}
}
