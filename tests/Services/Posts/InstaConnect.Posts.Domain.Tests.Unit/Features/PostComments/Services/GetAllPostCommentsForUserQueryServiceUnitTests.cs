using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class GetAllPostCommentsForUserQueryServiceUnitTests : BasePostCommentDomainQueryUnitTest
{
	private readonly GetAllPostCommentsForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostCommentsForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostCommentsForUserQuery _query;

	private readonly PostCommentQueryService _service;

	public GetAllPostCommentsForUserQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostComment);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CommentRepository, CollectionResponseFactory);

		UserRepository.SetupGetByIdAsync(_query, User, CancellationToken);
		CommentRepository.SetupGetAllForUserAsync(_query, PostComments, CancellationToken);
		CommentRepository.SetupGetTotalCountForUserAsync(_query, PostComments, CancellationToken);
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
		response.ShouldSatisfy(_query, User, PostComments);
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
	public async Task GetAllForUserAsync_ShouldCallTheCommentRepositoryGetAllForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetAllForUserAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheCommentRepositoryGetTotalCountForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetTotalCountForUserAsync(_query, CancellationToken);
	}
}
