namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class GetAllUsersQueryServiceUnitTests : BaseUserDomainQueryUnitTest
{
	private readonly GetAllUsersQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllUsersQueryBuilder _queryBuilder;
	private readonly GetAllUsersQuery _query;

	private readonly UserQueryService _service;

	public GetAllUsersQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(User);
		_query = _queryBuilder.Build();

		_service = new(Repository, CollectionResponseFactory);

		Repository.SetupGetAllAsync(_query, Users, CancellationToken);
		Repository.SetupGetTotalCountAsync(_query, Users, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Users);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
