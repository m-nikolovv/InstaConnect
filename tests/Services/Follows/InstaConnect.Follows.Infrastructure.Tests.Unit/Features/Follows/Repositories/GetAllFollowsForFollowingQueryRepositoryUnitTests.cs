using InstaConnect.Follows.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class GetAllFollowsForFollowingQueryRepositoryUnitTests : BaseFollowInfrastructureQueryUnitTest
{
	private readonly FollowsForFollowingFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly FollowsForFollowingFilterQueryBuilder _filterQueryBuilder;
	private readonly FollowsForFollowingFilterQuery _filterQuery;

	private readonly FollowsForFollowingSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly FollowsForFollowingSortingQueryBuilder _sortingQueryBuilder;
	private readonly FollowsForFollowingSortingQuery _sortingQuery;

	private readonly FollowsPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly FollowsPaginationQueryBuilder _paginationQueryBuilder;
	private readonly FollowsPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly FollowInclude _include;

	private readonly FollowQueryRepository _repository;

	public GetAllFollowsForFollowingQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Follow);
		_filterQuery = _filterQueryBuilder.Build();

		_sortingQueryBuilderFactory = new();
		_sortingQueryBuilder = _sortingQueryBuilderFactory.Create();
		_sortingQuery = _sortingQueryBuilder.Build();

		_paginationQueryBuilderFactory = new();
		_paginationQueryBuilder = _paginationQueryBuilderFactory.Create();
		_paginationQuery = _paginationQueryBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(Following);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollower().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
		Fluent.SetupMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		Fluent.SetupProjectToResponseWithoutFollowing(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Following, Follows);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheFluentApplyIncludes_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheFluentProjectToResponseWithoutFollowing_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToResponseWithoutFollowing(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheResponseFluentApplySorting_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheResponseFluentApplyPagination_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheResponseFluentToListAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForFollowingAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);
	}
}
