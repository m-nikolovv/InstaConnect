using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Services;

public class GetFollowByIdQueryServiceIntegrationTests : BaseFollowDomainQueryIntegrationTest
{
	private readonly GetFollowByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetFollowByIdQueryBuilder _queryBuilder;
	private readonly GetFollowByIdQuery _query;

	public GetFollowByIdQueryServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow, UserId);
		_query = _queryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetByIdAsync(_query, Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowFollowNotFoundException_WhenFollowNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Assert
		await Service.ShouldThrowFollowNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follow);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryIsValid()
	{
		// Act
		await Service.GetByIdAsync(_query, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(_query, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(_query, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowerId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(query, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithFollowingId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(query, Follow);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Service.GetByIdAsync(query, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(query, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(query, Follow);
	}
}
