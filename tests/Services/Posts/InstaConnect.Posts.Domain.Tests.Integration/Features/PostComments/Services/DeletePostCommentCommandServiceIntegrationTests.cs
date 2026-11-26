using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Services;

public class DeletePostCommentCommandServiceIntegrationTests : BasePostCommentDomainCommandIntegrationTest
{
	private readonly DeletePostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommentCommandBuilder _commandBuilder;
	private readonly DeletePostCommentCommand _command;

	public DeletePostCommentCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment);
		_command = _commandBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(_command, PostComment, CancellationToken);
		await base.InitializeAsync();
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(_command, PostComment, CancellationToken);
		await base.DisposeAsync();
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
	public async Task DeleteAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentForbiddenException_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await Service.ShouldThrowPostCommentForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(_command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(command, PostComment, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(command, PostComment, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(command, PostComment, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(_command, CancellationToken);

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
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(command, CancellationToken);

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
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postCommentPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentImageIds, CancellationToken);

		// Assert
		postCommentPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentImageIds, CancellationToken);

		// Assert
		postCommentPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentImages_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentImageIds, CancellationToken);

		// Assert
		postCommentPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentImages_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentImageIds, CancellationToken);

		// Assert
		postCommentPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postCommentPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentLikeIds, CancellationToken);

		// Assert
		postCommentPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentLikeIds, CancellationToken);

		// Assert
		postCommentPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentLikes_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentLikeIds, CancellationToken);

		// Assert
		postCommentPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentPostCommentLikes_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostCommentPostCommentLikeIds, CancellationToken);

		// Assert
		postCommentPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, PostComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostComment);
	}
}
