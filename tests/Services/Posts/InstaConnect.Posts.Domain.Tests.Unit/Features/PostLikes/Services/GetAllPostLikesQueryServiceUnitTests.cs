using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Services;

public class GetAllPostLikesQueryServiceUnitTests : BasePostLikeDomainQueryUnitTest
{
	private readonly GetAllPostLikesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostLikesQueryBuilder _queryBuilder;
	private readonly GetAllPostLikesQuery _query;

	private readonly PostLikeQueryService _service;

	public GetAllPostLikesQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, LikeRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, Post, CancellationToken);
		LikeRepository.SetupGetAllAsync(_query, PostLikes, CancellationToken);
		LikeRepository.SetupGetTotalCountAsync(_query, PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Post, PostLikes);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheLikeRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheLikeRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
