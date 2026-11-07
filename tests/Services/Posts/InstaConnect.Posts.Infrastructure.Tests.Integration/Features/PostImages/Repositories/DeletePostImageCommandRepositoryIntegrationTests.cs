using InstaConnect.Posts.Tests.Features.PostImages.DataAttributes.ImageId;

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

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostImage_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedPostImage = PostImageBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedPostImage, CancellationToken);
		var postImage = await ServiceScope.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		postImage.ShouldBeNull();
	}

	[Theory]
	[PostImageImageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostImage_WhenCommandAndImageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedPostImage = PostImageBuilder.WithImageId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedPostImage, CancellationToken);
		var postImage = await ServiceScope.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		postImage.ShouldBeNull();
	}
}
