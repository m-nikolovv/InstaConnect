using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Tests.Features.PostImages.DataAttributes.ImageId;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class GetPostImageByIdRangeCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public GetPostImageByIdRangeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(PostImages, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImages);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostImageIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImages);
	}

	[Theory]
	[PostImageImageIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndImageIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostImageIdRangeBuilder.WithImageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImages);
	}
}
