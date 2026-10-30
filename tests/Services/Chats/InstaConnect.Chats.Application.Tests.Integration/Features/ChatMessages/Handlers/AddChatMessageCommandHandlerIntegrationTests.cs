using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Content;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Handlers;

public class AddChatMessageCommandHandlerIntegrationTests : BaseChatMessageApplicationCommandIntegrationTest
{
	private readonly AddChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageCommandRequestBuilder _requestBuilder;
	private readonly AddChatMessageCommandRequest _request;

	private readonly AddChatMessageCommandRequestBuilder _invertedRequestBuilder;
	private readonly AddChatMessageCommandRequest _invertedRequest;

	public AddChatMessageCommandHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(Chat).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForContentAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesTooManyWithMessageData]
	[ChatMessageImagesTooLargeWithMessageData]
	[ChatMessageImagesInvalidContentTypeWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenImagesAreInvalid(
		IFormFileCollectionTransformer transformer, IFormFileCollectionMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForImagesAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Sender.ShouldThrowChatNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldAddChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldAddChatMessage_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishChatMessageAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldAddInvertedChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(_invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldAddInvertedChatMessage_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldAddChatMessageImages_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChatMessageImages_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddChatMessageImages_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(request);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldAddChatMessageImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldAddInvertedChatMessageImages_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(_invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddInvertedChatMessageImages_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddInvertedChatMessageImages_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	[ChatMessageImagesJpegData]
	[ChatMessageImagesPngData]
	[ChatMessageImagesWebpData]
	[ChatMessageImagesJpegDifferentCaseData]
	[ChatMessageImagesPngDifferentCaseData]
	[ChatMessageImagesWebpDifferentCaseData]
	public async Task SendAsync_ShouldAddInvertedChatMessageImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedRequest);
	}
}
