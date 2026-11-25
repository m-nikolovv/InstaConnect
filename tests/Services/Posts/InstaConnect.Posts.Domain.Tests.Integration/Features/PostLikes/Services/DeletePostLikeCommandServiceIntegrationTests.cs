using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostLikes.Services;

public class DeletePostLikeCommandServiceIntegrationTests : BasePostLikeDomainCommandIntegrationTest
{
	private readonly DeletePostLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostLikeCommandBuilder _commandBuilder;
	private readonly DeletePostLikeCommand _command;

	public DeletePostLikeCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostLike);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostLikeNotFoundException_WhenPostLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostLikeNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostLike_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostLike_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedPostLike = await LikeCacheHandler.GetByIdAsync(_command, CancellationToken);

		// Assert
		cachedPostLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostLike = await LikeCacheHandler.GetByIdAsync(command, CancellationToken);

		// Assert
		cachedPostLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostLike = await LikeCacheHandler.GetByIdAsync(command, CancellationToken);

		// Assert
		cachedPostLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedPost = await CacheHandler.GetByIdAsync(_command, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPost = await CacheHandler.GetByIdAsync(command, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPost = await CacheHandler.GetByIdAsync(command, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostLikeDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, PostLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostLikeDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostLikeDeletedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await LikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostLike);
	}
}
