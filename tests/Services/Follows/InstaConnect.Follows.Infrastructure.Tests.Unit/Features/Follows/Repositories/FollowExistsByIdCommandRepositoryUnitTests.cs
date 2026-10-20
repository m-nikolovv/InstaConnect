namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class FollowExistsByIdCommandRepositoryUnitTests : BaseFollowInfrastructureCommandUnitTest
{
	private readonly FollowCommandRepository _repository;

	public FollowExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(FollowId, Fluent);
		Fluent.SetupMatch(FollowId);
		Fluent.SetupAnyAsync(FollowId, Follow, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(FollowId, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, Follow);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(FollowId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(FollowId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(FollowId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(FollowId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(FollowId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(FollowId, CancellationToken);
	}
}
