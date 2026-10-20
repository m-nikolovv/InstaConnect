using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class GetPostCommentsTotalCountQueryRepositoryUnitTests : BasePostCommentInfrastructureQueryUnitTest
{
	private readonly PostCommentsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentsFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentsFilterQuery _filterQuery;

	private readonly PostCommentInclude _include;

	private readonly PostCommentQueryRepository _repository;

	public GetPostCommentsTotalCountQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostComment);
		_filterQuery = _filterQueryBuilder.Build();

		_include = CommentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPostCommentImages().Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, Fluent);
		Fluent.SetupApplyIncludes(_filterQuery, _include);
		Fluent.SetupMatch(_filterQuery);
		Fluent.SetupGetCountAsync(_filterQuery, PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, PostComments);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheCollectionAggregateFluent_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentApplyIncludes_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_filterQuery, _include);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentMatch_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldCallTheFluentGetCountAsync_WhenQueryIsValid()
	{
		// Act
		await _repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneGetCountAsync(_filterQuery, CancellationToken);
	}
}
