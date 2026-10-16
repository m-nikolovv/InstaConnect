using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class GetAllPostLikesForUserQueryRepositoryUnitTests : BasePostLikeInfrastructureQueryUnitTest
{
	private readonly PostLikesForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostLikesForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostLikesForUserFilterQuery _filterQuery;

	private readonly PostLikesForUserSortingQueryBuilderFactory _sortingQueryBuilderFactory;
	private readonly PostLikesForUserSortingQueryBuilder _sortingQueryBuilder;
	private readonly PostLikesForUserSortingQuery _sortingQuery;

	private readonly PostLikesPaginationQueryBuilderFactory _paginationQueryBuilderFactory;
	private readonly PostLikesPaginationQueryBuilder _paginationQueryBuilder;
	private readonly PostLikesPaginationQuery _paginationQuery;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostLikeInclude _include;

	private readonly PostLikeQueryRepository _repository;

	public GetAllPostLikesForUserQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostLike);
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

		_include = LikeIncludeBuilderFactory.Create().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build()).Build();

		_repository = new(Collection, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
		Fluent.SetupMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		Fluent.SetupProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
		ResponseFluent.SetupToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, User, PostLikes);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheFluentProjectToResponseWithoutUser_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToResponseWithoutUser(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentApplySorting_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplySorting(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentApplyPagination_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		ResponseFluent.ShouldHaveReceivedOneApplyPagination(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheResponseFluentToListAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetAllForUserAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneToListAsync(_filterQuery, _sortingQuery, _paginationQuery, _currentUserQuery, CancellationToken);
	}
}
