using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetAllUserClaimsQueryRepositoryUnitTests : BaseUserClaimInfrastructureQueryUnitTest
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

	private readonly UserClaimQueryRepository _repository;

	public GetAllUserClaimsQueryRepositoryUnitTests()
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

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Fluent);
		Fluent.SetupMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		Fluent.SetupProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, UserClaims, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, UserClaims);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheFluentProjectToResponseWithoutUser_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheResponseFluentApplySorting_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheResponseFluentApplyPagination_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheResponseFluentToListAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);
	}
}
