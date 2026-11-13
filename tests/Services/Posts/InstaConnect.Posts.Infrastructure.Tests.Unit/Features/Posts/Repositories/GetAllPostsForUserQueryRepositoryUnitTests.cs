using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class GetAllPostsForUserQueryRepositoryUnitTests : BasePostInfrastructureQueryUnitTest
{
	private readonly PostsForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostsForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostsForUserFilterQuery _filterQuery;

	private readonly PostsForUserSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly PostsForUserSortingQueryBuilder _sortingQueryBuilder;
	private readonly PostsForUserSortingQuery _sortingQuery;

	private readonly PostsPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly PostsPaginationQueryBuilder _paginationQueryBuilder;
	private readonly PostsPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostInclude _include;

	private readonly PostQueryRepository _repository;

	public GetAllPostsForUserQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Post);
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

		_include = IncludeBuilderFactory.Create().WithPostLikes().WithPostComments().WithPostImages().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Fluent);
		Fluent.SetupInclude(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
		Fluent.SetupMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		Fluent.SetupProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupSort(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupPaginate(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Posts, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, User, Posts);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheFluentInclude_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneInclude(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheFluentProjectToResponseWithoutUser_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentSort_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneSort(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentPaginate_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOnePaginate(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentToListAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);
	}
}
