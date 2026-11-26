namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class GetAllPostsQueryServiceUnitTests : BasePostDomainQueryUnitTest
{
	private readonly GetAllPostsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostsQueryBuilder _queryBuilder;
	private readonly GetAllPostsQuery _query;

	private readonly PostQueryService _service;

	public GetAllPostsQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		Repository.SetupGetAllAsync(_query, Posts, CancellationToken);
		Repository.SetupGetTotalCountAsync(_query, Posts, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Posts);
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
