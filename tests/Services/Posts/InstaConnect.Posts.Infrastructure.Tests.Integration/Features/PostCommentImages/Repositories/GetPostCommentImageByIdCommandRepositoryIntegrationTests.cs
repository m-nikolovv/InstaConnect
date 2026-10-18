using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;
using InstaConnect.Posts.Tests.Features.PostCommentImages.DataAttributes.ImageId;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentImages.Repositories;

public class GetPostCommentImageByIdCommandRepositoryIntegrationTests : BasePostCommentImageInfrastructureCommandIntegrationTest
{
	public GetPostCommentImageByIdCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostCommentImage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostCommentImage, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentImage);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentImageIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentImage);
	}

	[Theory]
	[PostCommentImageImageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndImageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentImageIdBuilder.WithImageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentImage);
	}
}
