using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class GetPostCommentImageByIdCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public GetPostCommentImageByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection);

		Collection.SetupAggregateFluent(PostCommentImageId, Fluent);
		Fluent.SetupMatch(PostCommentImageId);
		Fluent.SetupFirstOrDefaultAsync(PostCommentImageId, PostCommentImage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentImageId, PostCommentImage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentImageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentImageId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentImageId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostCommentImageId, CancellationToken);
	}
}
