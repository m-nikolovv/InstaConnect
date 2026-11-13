namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class GetFollowByIdRangeCommandRepositoryUnitTests : BaseFollowInfrastructureCommandUnitTest
{
	private readonly FollowInclude _include;

	private readonly FollowCommandRepository _repository;

	public GetFollowByIdRangeCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(FollowIds, Fluent);
		Fluent.SetupInclude(FollowIds, _include);
		Fluent.SetupMatch(FollowIds);
		Fluent.SetupToListAsync(FollowIds, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowIds, Follows);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(FollowIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentInclude_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(FollowIds, _include);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(FollowIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(FollowIds, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(FollowIds, CancellationToken);
	}
}
