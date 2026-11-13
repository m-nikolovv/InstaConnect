using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Services;

public class DeletePostCommandServiceIntegrationTests : BasePostDomainCommandIntegrationTest
{
	private readonly DeletePostCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommandBuilder _commandBuilder;
	private readonly DeletePostCommand _command;

	public DeletePostCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
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
	public async Task DeleteAsync_ShouldThrowPostForbiddenException_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await Service.ShouldThrowPostForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePost_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePost_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePost_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, Post);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, Post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, Post);
	}
}
