using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class GetPostCommentsForUserTotalCountQueryRepositoryUnitTests : BasePostCommentInfrastructureQueryUnitTest
{
	private readonly PostCommentsForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentsForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentsForUserFilterQuery _filterQuery;

	private readonly PostCommentQueryRepository _repository;

	public GetPostCommentsForUserTotalCountQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostComment);
		_filterQuery = _filterQueryBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, Fluent);
		Fluent.SetupMatch(_filterQuery);
		Fluent.SetupGetCountAsync(_filterQuery, PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, PostComments);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheFluentGetCountAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneGetCountAsync(_filterQuery, CancellationToken);
	}
}
