using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Handlers;

public class AddPostCommandHandlerIntegrationTests : BasePostApplicationCommandIntegrationTest
{
	private readonly AddPostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommandRequest _request;

	public AddPostCommandHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Post.PostImages.Count);
		_request = _requestBuilder.Build();
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
	[PostTitleNullWithMessageData]
	[PostTitleEmptyWithMessageData]
	[PostTitleTooShortWithMessageData]
	[PostTitleTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForTitleAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostContentNullWithMessageData]
	[PostContentEmptyWithMessageData]
	[PostContentTooShortWithMessageData]
	[PostContentTooLongWithMessageData]
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
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, post);
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
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, post);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, post);
	}

	[Fact]
	public async Task SendAsync_ShouldAddPost_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPost_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(request);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task SendAsync_ShouldAddPost_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishPostAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostAddedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, post);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task SendAsync_ShouldPublishPostAddedEvent_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, post);
	}

	[Fact]
	public async Task SendAsync_ShouldAddPostImages_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddPostImages_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(request);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task SendAsync_ShouldAddPostImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldBeEmpty();
	}
}
