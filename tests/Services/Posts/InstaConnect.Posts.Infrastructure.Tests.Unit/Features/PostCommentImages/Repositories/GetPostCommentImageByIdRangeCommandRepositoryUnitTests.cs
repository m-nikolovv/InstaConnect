using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class GetPostCommentImageByIdRangeCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public GetPostCommentImageByIdRangeCommandRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(PostCommentImageIds, Fluent);
		Fluent.SetupMatch(PostCommentImageIds);
		Fluent.SetupToListAsync(PostCommentImageIds, PostCommentImages, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(PostCommentImageIds, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentImageIds, PostCommentImages);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentImageIds, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentImageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentImageIds, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentImageIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentImageIds, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(PostCommentImageIds, CancellationToken);
	}
}
