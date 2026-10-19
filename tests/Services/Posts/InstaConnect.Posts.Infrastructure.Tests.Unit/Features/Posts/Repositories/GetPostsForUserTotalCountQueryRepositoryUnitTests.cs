using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class GetPostsForUserTotalCountQueryRepositoryUnitTests : BasePostInfrastructureQueryUnitTest
{
	private readonly PostsForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostsForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostsForUserFilterQuery _filterQuery;

	private readonly PostInclude _include;

	private readonly PostQueryRepository _repository;

	public GetPostsForUserTotalCountQueryRepositoryUnitTests()
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Post);
		_filterQuery = _filterQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithPostLikes().WithPostImages().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_filterQuery, Fluent);
		Fluent.SetupApplyIncludes(_filterQuery, _include);
		Fluent.SetupMatch(_filterQuery);
		Fluent.SetupGetCountAsync(_filterQuery, Posts, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Posts);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_filterQuery, _include);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_filterQuery);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldCallTheFluentGetCountAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneGetCountAsync(_filterQuery, CancellationToken);
	}
}
