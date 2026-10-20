using InstaConnect.Posts.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Tests.Features.PostImages.DataAttributes.ImageId;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class GetPostImageByIdCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public GetPostImageByIdCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostImage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostImage, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImage);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostImageIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImage);
	}

	[Theory]
	[PostImageImageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndImageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostImageIdBuilder.WithImageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImage);
	}
}
