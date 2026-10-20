using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class GetAllPostsForUserQueryRepositoryIntegrationTests : BasePostInfrastructureQueryIntegrationTest
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

	public GetAllPostsForUserQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
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
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, User, Posts);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.GetAllForUserAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, User, Posts);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Repository.GetAllForUserAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, User, Posts);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, User, Posts);
	}

	[Theory]
	[PostsSortOrderWithAscendingTermData]
	[PostsSortOrderWithDescendingTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllForUserAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, User, Posts, termTransformer);
	}

	[Theory]
	[PostsForUserSortTermWithCreatedAtTermData]
	[PostsForUserSortTermWithTitleTermData]
	[PostsForUserSortTermWithUserNameTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostsForUserSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllForUserAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, User, Posts, termTransformer);
	}
}
