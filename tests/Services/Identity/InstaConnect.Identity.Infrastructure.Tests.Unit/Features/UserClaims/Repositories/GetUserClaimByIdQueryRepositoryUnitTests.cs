using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.Common.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetUserClaimByIdQueryRepositoryUnitTests : BaseUserClaimInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly UserClaimInclude _include;

	private readonly UserClaimQueryRepository _repository;

	public GetUserClaimByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(UserClaimId, _currentUserQuery, Fluent);
		Fluent.SetupInclude(UserClaimId, _currentUserQuery, _include);
		Fluent.SetupMatch(UserClaimId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(UserClaimId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsNotCached()
	{
		// Act
		var response = await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserClaimId, _currentUserQuery, UserClaim);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(UserClaimId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerAddAsync_WhenResponseIsNotCached()
	{
		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneAddAsync(UserClaim, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserClaimId, _currentUserQuery, UserClaim);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCollectionAggregateFluent_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedZeroAggregateFluent(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentInclude_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroInclude(UserClaimId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentMatch_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroMatch(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheFluentProjectToFullResponse_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedZeroProjectToFullResponse(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheResponseFluentFirstOrDefaultAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedZeroFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenResponseIsCached()
	{
		// Arrange
		CacheHandler.SetupGetByIdAsync(UserClaimId, _currentUserQuery, UserClaim, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(UserClaim, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		var response = await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCacheHandlerGetByIdAsync_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneGetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentInclude_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(UserClaimId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(UserClaimId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldNotCallTheCacheHandlerAddAsync_WhenUserClaimIsNotFound()
	{
		// Arrange
		ResponseFluent.RemoveFirstOrDefaultAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Act
		await _repository.GetByIdAsync(UserClaimId, _currentUserQuery, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedZeroAddAsync(UserClaim, _currentUserQuery, CancellationToken);
	}
}
