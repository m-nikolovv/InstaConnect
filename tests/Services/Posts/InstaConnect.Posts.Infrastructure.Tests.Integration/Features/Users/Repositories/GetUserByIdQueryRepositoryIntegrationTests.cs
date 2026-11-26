using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class GetUserByIdQueryRepositoryIntegrationTests : BaseUserInfrastructureQueryIntegrationTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetUserByIdQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeGetByIdAsync(User, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeGetByIdAsync(User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, _currentUserQuery, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = UserIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, User);
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
		var response = await Repository.GetByIdAsync(UserId, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserId, currentUserQuery, User);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCacheUser_WhenQueryIsValid()
	{
		// Act
		await Repository.GetByIdAsync(UserId, _currentUserQuery, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(UserId, _currentUserQuery, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(UserId, _currentUserQuery, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheUser_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = UserIdBuilder.WithId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(id, _currentUserQuery, User);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldCacheUser_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		await Repository.GetByIdAsync(UserId, currentUserQuery, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(UserId, currentUserQuery, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(UserId, currentUserQuery, User);
	}
}
