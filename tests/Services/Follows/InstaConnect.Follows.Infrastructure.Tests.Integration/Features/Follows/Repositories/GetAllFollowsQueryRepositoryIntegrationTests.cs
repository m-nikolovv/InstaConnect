using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class GetAllFollowsQueryRepositoryIntegrationTests : BaseFollowInfrastructureQueryIntegrationTest
{
	private readonly FollowsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly FollowsFilterQueryBuilder _filterQueryBuilder;
	private readonly FollowsFilterQuery _filterQuery;

	private readonly FollowsSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly FollowsSortingQueryBuilder _sortingQueryBuilder;
	private readonly FollowsSortingQuery _sortingQuery;

	private readonly FollowsPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly FollowsPaginationQueryBuilder _paginationQueryBuilder;
	private readonly FollowsPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetAllFollowsQueryRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
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
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(Follower);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Follower, Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Follower, Follows);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndFollowingNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithFollowingName(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Follower, Follows);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, Follower, Follows);
	}

	[Theory]
	[FollowsSortOrderWithAscendingTermData]
	[FollowsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, Follower, Follows, termTransformer);
	}

	[Theory]
	[FollowsSortTermWithCreatedAtTermData]
	[FollowsSortTermWithFollowingNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<FollowsSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, Follower, Follows, termTransformer);
	}
}
