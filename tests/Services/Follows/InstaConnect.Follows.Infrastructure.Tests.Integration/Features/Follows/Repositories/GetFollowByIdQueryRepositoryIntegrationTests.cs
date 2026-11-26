using InstaConnect.Follows.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class GetFollowByIdQueryRepositoryIntegrationTests : BaseFollowInfrastructureQueryIntegrationTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetFollowByIdQueryRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(Follower);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetByIdAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = FollowIdBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = FollowIdBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(FollowId, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(FollowId, currentUserQuery, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryIsValid()
	{
		// Act
		await Repository.GetByIdAsync(FollowId, _currentUserQuery, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(FollowId, _currentUserQuery, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(FollowId, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = FollowIdBuilder.WithFollowerId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = FollowIdBuilder.WithFollowingId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheFollow_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(FollowId, currentUserQuery, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(FollowId, currentUserQuery, CancellationToken);

		// Assert
		cachedFollow.ShouldSatisfy(FollowId, currentUserQuery, Follow);
	}
}
