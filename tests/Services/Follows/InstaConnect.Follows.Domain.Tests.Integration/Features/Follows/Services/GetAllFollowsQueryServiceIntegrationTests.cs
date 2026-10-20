using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Services;

public class GetAllFollowsQueryServiceIntegrationTests : BaseFollowDomainQueryIntegrationTest
{
	private readonly GetAllFollowsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllFollowsQueryBuilder _queryBuilder;
	private readonly GetAllFollowsQuery _query;

	public GetAllFollowsQueryServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowFollowerNotFoundException_WhenFollowerNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowerNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Follower, Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follower, Follows);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndFollowingNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowingName(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follower, Follows);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follower, Follows);
	}

	[Theory]
	[FollowsSortOrderWithAscendingTermData]
	[FollowsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follower, Follows, termTransformer);
	}

	[Theory]
	[FollowsSortTermWithCreatedAtTermData]
	[FollowsSortTermWithFollowingNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<FollowsSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follower, Follows, termTransformer);
	}
}
