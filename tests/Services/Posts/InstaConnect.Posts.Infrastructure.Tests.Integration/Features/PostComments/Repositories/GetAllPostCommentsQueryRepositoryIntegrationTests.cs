using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class GetAllPostCommentsQueryRepositoryIntegrationTests : BasePostCommentInfrastructureQueryIntegrationTest
{
	private readonly PostCommentsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentsFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentsFilterQuery _filterQuery;

	private readonly PostCommentsSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly PostCommentsSortingQueryBuilder _sortingQueryBuilder;
	private readonly PostCommentsSortingQuery _sortingQuery;

	private readonly PostCommentsPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly PostCommentsPaginationQueryBuilder _paginationQueryBuilder;
	private readonly PostCommentsPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetAllPostCommentsQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostComment);
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
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Post, PostComments);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Post, PostComments);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Post, PostComments);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, currentUserQuery, Post, PostComments);
	}

	[Theory]
	[PostCommentsSortOrderWithAscendingTermData]
	[PostCommentsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, Post, PostComments, termTransformer);
	}

	[Theory]
	[PostCommentsSortTermWithCreatedAtTermData]
	[PostCommentsSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostCommentsSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var sortingQuery = _sortingQueryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Repository.GetAllAsync(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, sortingQuery, _paginationQuery, _currentUserQuery, Post, PostComments, termTransformer);
	}
}
