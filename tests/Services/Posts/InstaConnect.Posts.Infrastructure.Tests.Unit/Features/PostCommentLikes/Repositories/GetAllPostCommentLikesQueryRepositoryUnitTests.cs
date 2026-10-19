using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class GetAllPostCommentLikesQueryRepositoryUnitTests : BasePostCommentLikeInfrastructureQueryUnitTest
{
	private readonly PostCommentLikesFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentLikesFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentLikesFilterQuery _filterQuery;

	private readonly PostCommentLikesSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly PostCommentLikesSortingQueryBuilder _sortingQueryBuilder;
	private readonly PostCommentLikesSortingQuery _sortingQuery;

	private readonly PostCommentLikesPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly PostCommentLikesPaginationQueryBuilder _paginationQueryBuilder;
	private readonly PostCommentLikesPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostCommentLikeInclude _include;

	private readonly PostCommentLikeQueryRepository _repository;

	public GetAllPostCommentLikesQueryRepositoryUnitTests()
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

		_include = CommentLikeIncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
		Fluent.SetupMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		Fluent.SetupProjectToResponseWithoutPostComment(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, PostComment, PostCommentLikes);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheFluentProjectToResponseWithoutPostComment_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToResponseWithoutPostComment(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheResponseFluentApplySorting_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheResponseFluentApplyPagination_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheResponseFluentToListAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);
	}
}
