using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm.ForFollowing;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Services;

public class GetAllFollowsForFollowingQueryServiceIntegrationTests : BaseFollowDomainQueryIntegrationTest
{
	private readonly GetAllFollowsForFollowingQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllFollowsForFollowingQueryBuilder _queryBuilder;
	private readonly GetAllFollowsForFollowingQuery _query;

	public GetAllFollowsForFollowingQueryServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
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
	public async Task GetAllForFollowingAsync_ShouldThrowFollowingNotFoundException_WhenFollowingNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowingNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Following, Follows);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.GetAllForFollowingAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Following, Follows);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryAndFollowerNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await Service.GetAllForFollowingAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Following, Follows);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllForFollowingAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Following, Follows);
	}

	[Theory]
	[FollowsSortOrderWithAscendingTermData]
	[FollowsSortOrderWithDescendingTermData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllForFollowingAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Following, Follows, termTransformer);
	}

	[Theory]
	[FollowsForFollowingSortTermWithCreatedAtTermData]
	[FollowsForFollowingSortTermWithFollowerNameTermData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllForFollowingAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Following, Follows, termTransformer);
	}
}
