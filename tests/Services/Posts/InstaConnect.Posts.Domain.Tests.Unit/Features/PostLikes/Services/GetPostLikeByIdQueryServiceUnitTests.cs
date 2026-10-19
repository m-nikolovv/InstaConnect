using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Services;

public class GetPostLikeByIdQueryServiceUnitTests : BasePostLikeDomainQueryUnitTest
{
	private readonly GetPostLikeByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostLikeByIdQueryBuilder _queryBuilder;
	private readonly GetPostLikeByIdQuery _query;

	private readonly PostLikeQueryService _service;

	public GetPostLikeByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, LikeRepository, CollectionResponseFactory);

		Repository.SetupExistsByIdAsync(_query, CancellationToken);
		LikeRepository.SetupGetByIdAsync(_query, PostLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostLikeNotFoundException_WhenPostLikeNotFound()
	{
		// Arrange
		LikeRepository.RemoveGetByIdAsync(_query, PostLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostLikeNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheLikeRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}
}
