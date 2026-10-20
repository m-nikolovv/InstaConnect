using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.ChatMessages.Controllers;

public class DeleteChatMessageControllerIntegrationTests : BaseChatMessagePresentationCommandIntegrationTest
{
	private readonly DeleteChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteChatMessageApiRequestBuilder _requestBuilder;
	private readonly DeleteChatMessageApiRequest _request;

	private readonly DeleteChatMessageApiRequestBuilder _invertedRequestBuilder;
	private readonly DeleteChatMessageApiRequest _invertedRequest;

	public DeleteChatMessageControllerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(ChatMessage).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldThrowValidationException_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldThrowValidationException_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[ChatMessageIdNullWithMessageData]
	[ChatMessageIdEmptyWithMessageData]
	[ChatMessageIdTooShortWithMessageData]
	[ChatMessageIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldThrowValidationException_WhenMessageIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForMessageIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Controller.ShouldThrowChatNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Controller.ShouldThrowChatMessageNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatMessageForbiddenException_WhenChatMessageForbidden()
	{
		// Arrange

		// Assert
		await Controller.ShouldThrowChatMessageForbiddenExceptionAsync(_invertedRequest, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.DeleteAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnInvertedNoContentStatusCode_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await Controller.DeleteAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnInvertedNoContentStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnInvertedNoContentStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldReturnInvertedNoContentStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Controller.DeleteAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await Controller.DeleteAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Controller.DeleteAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Controller.DeleteAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		await Controller.DeleteAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteAsync(_request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		await Controller.DeleteAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await Controller.DeleteAsync(_invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedRequest, InvertedChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Controller.DeleteAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Controller.DeleteAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		await Controller.DeleteAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}
}
