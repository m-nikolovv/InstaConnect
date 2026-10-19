using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikeByIdQueryRepositoryUnitTests : BasePostCommentLikeInfrastructureQueryUnitTest
{
	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly PostCommentLikeInclude _include;

	private readonly PostCommentLikeQueryRepository _repository;

	public GetPostCommentLikeByIdQueryRepositoryUnitTests()
	{
		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = CommentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(CommentIncludeBuilderFactory.Create().WithUser().WithPost(IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build()).WithPostCommentLikes().WithPostCommentImages().Build()).Build();

		_repository = new(Collection, IncludeBuilderFactory, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostCommentLikeId, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(PostCommentLikeId, _currentUserQuery, _include);
		Fluent.SetupMatch(PostCommentLikeId, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(PostCommentLikeId, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikeId, _currentUserQuery, PostCommentLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(PostCommentLikeId, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(PostCommentLikeId, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostCommentLikeId, _currentUserQuery, CancellationToken);
	}
}
