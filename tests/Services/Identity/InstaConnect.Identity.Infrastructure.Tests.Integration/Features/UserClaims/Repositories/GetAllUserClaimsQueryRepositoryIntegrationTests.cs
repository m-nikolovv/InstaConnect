using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortOrder;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortTerm;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class GetAllUserClaimsQueryRepositoryIntegrationTests : BaseUserClaimInfrastructureQueryIntegrationTest
{
	private readonly UserClaimsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly UserClaimsFilterQueryBuilder _filterQueryBuilder;
	private readonly UserClaimsFilterQuery _filterQuery;

	private readonly UserClaimsSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly UserClaimsSortingQueryBuilder _sortingQueryBuilder;
	private readonly UserClaimsSortingQuery _sortingQuery;

	private readonly UserClaimsPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly UserClaimsPaginationQueryBuilder _paginationQueryBuilder;
	private readonly UserClaimsPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetAllUserClaimsQueryRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(UserClaim);
		_filterQuery = _filterQueryBuilder.Build();

		_sortingQueryBuilderFactory = new();
		_sortingQueryBuilder = _sortingQueryBuilderFactory.Create();
		_sortingQuery = _sortingQueryBuilder.Build();

		_paginationQueryBuilderFactory = new();
		_paginationQueryBuilder = _paginationQueryBuilderFactory.Create();
		_paginationQuery = _paginationQueryBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(UserClaims, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, UserClaims);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, UserClaims);
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
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, UserClaims);
	}

	[Theory]
	[UserClaimsSortOrderWithAscendingTermData]
	[UserClaimsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<UserClaim> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, UserClaims, termTransformer);
	}

	[Theory]
	[UserClaimsSortTermWithCreatedAtTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<UserClaimsSortTerm> transformer, ISortEnumTermTransformer<UserClaim> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, UserClaims, termTransformer);
	}
}
