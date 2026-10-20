namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Services;

public class GetAllPostLikesForUserQueryServiceUnitTests : BasePostLikeDomainQueryUnitTest
{
	private readonly GetAllPostLikesForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostLikesForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostLikesForUserQuery _query;

	private readonly PostLikeQueryService _service;

	public GetAllPostLikesForUserQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(PostLike);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, LikeRepository, CollectionResponseFactory);

		UserRepository.SetupGetByIdAsync(_query, User, CancellationToken);
		LikeRepository.SetupGetAllForUserAsync(_query, PostLikes, CancellationToken);
		LikeRepository.SetupGetTotalCountForUserAsync(_query, PostLikes, CancellationToken);
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
		response.ShouldSatisfy(_query, User, PostLikes);
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
	public async Task GetAllForUserAsync_ShouldCallTheLikeRepositoryGetAllForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetAllForUserAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheLikeRepositoryGetTotalCountForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetTotalCountForUserAsync(_query, CancellationToken);
	}
}
