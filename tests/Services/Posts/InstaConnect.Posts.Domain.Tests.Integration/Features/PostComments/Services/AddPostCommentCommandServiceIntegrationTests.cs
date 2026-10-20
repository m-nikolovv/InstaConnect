using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Services;

public class AddPostCommentCommandServiceIntegrationTests : BasePostCommentDomainCommandIntegrationTest
{
	private readonly AddPostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommentCommandBuilder _commandBuilder;
	private readonly AddPostCommentCommand _command;

	public AddPostCommentCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post, User, PostComment.PostCommentImages.Count);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postComment);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostComment_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostComment_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldAddPostComment_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postComment);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(command);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldAddPostCommentImages_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldBeEmpty();
	}
}
