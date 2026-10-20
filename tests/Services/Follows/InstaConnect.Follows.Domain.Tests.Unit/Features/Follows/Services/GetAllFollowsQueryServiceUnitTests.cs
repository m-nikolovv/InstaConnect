namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class GetAllFollowsQueryServiceUnitTests : BaseFollowDomainQueryUnitTest
{
	private readonly GetAllFollowsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllFollowsQueryBuilder _queryBuilder;
	private readonly GetAllFollowsQuery _query;

	private readonly FollowQueryService _service;

	public GetAllFollowsQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		UserRepository.SetupGetByIdAsync(_query, Follower, CancellationToken);
		Repository.SetupGetAllAsync(_query, Follows, CancellationToken);
		Repository.SetupGetTotalCountAsync(_query, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowFollowerNotFoundException_WhenFollowerNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_query, Follower, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowerNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Follower, Follows);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
