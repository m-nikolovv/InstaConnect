using InstaConnect.Posts.Tests.Features.PostCommentImages.DataAttributes.ImageId;

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

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentImage_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedPostCommentImage = PostCommentImageBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedPostCommentImage, CancellationToken);
		var postCommentImage = await ServiceScope.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		postCommentImage.ShouldBeNull();
	}

	[Theory]
	[PostCommentImageImageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentImage_WhenCommandAndImageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var deletedPostCommentImage = PostCommentImageBuilder.WithImageId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedPostCommentImage, CancellationToken);
		var postCommentImage = await ServiceScope.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		postCommentImage.ShouldBeNull();
	}
}
