using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class GetPostLikeByIdQueryRepositoryUnitTests : BasePostLikeInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostLikeInclude _include;

	private readonly PostLikeQueryRepository _repository;

	public GetPostLikeByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = LikeIncludeBuilderFactory.Create().WithUser().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build()).Build();

		_repository = new(Collection, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostLikeId, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(PostLikeId, _currentUserQuery, _include);
		Fluent.SetupMatch(PostLikeId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(PostLikeId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(PostLikeId, _currentUserQuery, PostLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, _currentUserQuery, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(PostLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostLikeId, _currentUserQuery, CancellationToken);
	}
}
