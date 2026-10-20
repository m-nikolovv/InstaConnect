using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class PostLikeExistsByIdQueryRepositoryUnitTests : BasePostLikeInfrastructureQueryUnitTest
{
	private readonly PostLikeQueryRepository _repository;

	public PostLikeExistsByIdQueryRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostLikeId, Fluent);
		Fluent.SetupMatch(PostLikeId);
		Fluent.SetupAnyAsync(PostLikeId, PostLike, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, PostLike);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(PostLikeId, CancellationToken);
	}
}
