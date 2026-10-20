using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class GetAllPostCommentLikesForUserQueryRepositoryUnitTests : BasePostCommentLikeInfrastructureQueryUnitTest
{
	private readonly PostCommentLikesForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentLikesForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentLikesForUserFilterQuery _filterQuery;

	private readonly PostCommentLikesForUserSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly PostCommentLikesForUserSortingQueryBuilder _sortingQueryBuilder;
	private readonly PostCommentLikesForUserSortingQuery _sortingQuery;

	private readonly PostCommentLikesPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly PostCommentLikesPaginationQueryBuilder _paginationQueryBuilder;
	private readonly PostCommentLikesPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostCommentLikeInclude _include;

	private readonly PostCommentLikeQueryRepository _repository;

	public GetAllPostCommentLikesForUserQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostCommentLike);
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

		_include = CommentLikeIncludeBuilderFactory.Create().WithPostComment(CommentIncludeBuilderFactory.Create().WithUser().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build()).WithPostCommentLikes().WithPostCommentImages().Build()).Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
		Fluent.SetupMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		Fluent.SetupProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, User, PostCommentLikes);
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
	public async Task GetAllForUserAsync_ShouldCallTheFluentApplyIncludes_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
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
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentApplySorting_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentApplyPagination_WhenQueryIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
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
