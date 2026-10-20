using InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class GetPostImageByIdCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public GetPostImageByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(PostImageId, Fluent);
		Fluent.SetupMatch(PostImageId);
		Fluent.SetupFirstOrDefaultAsync(PostImageId, PostImage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImageId, PostImage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostImageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostImageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostImageId, CancellationToken);
	}
}
