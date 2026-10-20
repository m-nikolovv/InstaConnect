namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class GetUserByIdQueryServiceUnitTests : BaseUserDomainQueryUnitTest
{
	private readonly GetUserByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetUserByIdQueryBuilder _queryBuilder;
	private readonly GetUserByIdQuery _query;

	private readonly UserQueryService _service;

	public GetUserByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(User);
		_query = _queryBuilder.Build();

		_service = new(Repository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, User);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}
}
