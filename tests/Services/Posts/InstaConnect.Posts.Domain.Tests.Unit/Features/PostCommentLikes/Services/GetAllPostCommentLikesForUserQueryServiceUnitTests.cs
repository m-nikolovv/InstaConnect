using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class GetAllPostCommentLikesForUserQueryServiceUnitTests : BasePostCommentLikeDomainQueryUnitTest
{
	private readonly GetAllPostCommentLikesForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentLikesForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentLikesForUserQuery _query;

	private readonly PostCommentLikeQueryService _service;

	public GetAllPostCommentLikesForUserQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostCommentLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CommentLikeRepository, CollectionResponseFactory);

		UserRepository.SetupGetByIdAsync(_query, User, CancellationToken);
		CommentLikeRepository.SetupGetAllForUserAsync(_query, PostCommentLikes, CancellationToken);
		CommentLikeRepository.SetupGetTotalCountForUserAsync(_query, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_query, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, User, PostCommentLikes);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCommentLikeRepositoryGetAllForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldHaveReceivedOneGetAllForUserAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCommentLikeRepositoryGetTotalCountForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldHaveReceivedOneGetTotalCountForUserAsync(_query, CancellationToken);
	}
}
