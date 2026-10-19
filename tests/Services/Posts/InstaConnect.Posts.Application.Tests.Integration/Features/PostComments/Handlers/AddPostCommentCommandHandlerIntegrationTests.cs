using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Handlers;

public class AddPostCommentCommandHandlerIntegrationTests : BasePostCommentApplicationCommandIntegrationTest
{
	private readonly AddPostCommentCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommentCommandRequest _request;

	public AddPostCommentCommandHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post, User, PostComment.PostCommentImages.Count);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			messageTransformer, request, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentContentNullWithMessageData]
	[PostCommentContentEmptyWithMessageData]
	[PostCommentContentTooShortWithMessageData]
	[PostCommentContentTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForContentAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, postComment);
	}

	[Fact]
	public async Task SendAsync_ShouldAddPostComment_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPostComment_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPostComment_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task SendAsync_ShouldAddPostComment_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, postComment);
	}

	[Fact]
	public async Task SendAsync_ShouldAddPostCommentImages_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(_request);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPostCommentImages_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldSatisfy(request);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task SendAsync_ShouldAddPostCommentImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.PostCommentImages.ShouldBeEmpty();
	}
}
