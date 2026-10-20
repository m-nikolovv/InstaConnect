namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class PostLikeExistsByIdCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeCommandRepository _repository;

	public PostLikeExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostLikeId, Fluent);
		Fluent.SetupMatch(PostLikeId);
		Fluent.SetupAnyAsync(PostLikeId, PostLike, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, PostLike);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostLikeId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(PostLikeId, CancellationToken);
	}
}
