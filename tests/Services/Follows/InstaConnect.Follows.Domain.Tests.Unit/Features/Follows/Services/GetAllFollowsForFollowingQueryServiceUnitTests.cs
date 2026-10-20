namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class GetAllFollowsForFollowingQueryServiceUnitTests : BaseFollowDomainQueryUnitTest
{
	private readonly GetAllFollowsForFollowingQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllFollowsForFollowingQueryBuilder _queryBuilder;
	private readonly GetAllFollowsForFollowingQuery _query;

	private readonly FollowQueryService _service;

	public GetAllFollowsForFollowingQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		UserRepository.SetupGetByIdAsync(_query, Following, CancellationToken);
		Repository.SetupGetAllForFollowingAsync(_query, Follows, CancellationToken);
		Repository.SetupGetTotalCountForFollowingAsync(_query, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldThrowFollowingNotFoundException_WhenFollowingNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_query, Following, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowingNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Following, Follows);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheRepositoryGetAllForFollowingAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetAllForFollowingAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheRepositoryGetTotalCountForFollowingAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetTotalCountForFollowingAsync(_query, CancellationToken);
	}
}
