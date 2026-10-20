using InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class GetPostImageByIdRangeCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public GetPostImageByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(PostImageIds, Fluent);
		Fluent.SetupMatch(PostImageIds);
		Fluent.SetupToListAsync(PostImageIds, PostImages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostImageIds, PostImages);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostImageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostImageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(PostImageIds, CancellationToken);
	}
}
