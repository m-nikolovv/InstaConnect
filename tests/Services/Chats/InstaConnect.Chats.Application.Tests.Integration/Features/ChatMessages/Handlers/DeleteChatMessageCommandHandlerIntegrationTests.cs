using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Handlers;

public class DeleteChatMessageCommandHandlerIntegrationTests : BaseChatMessageApplicationCommandIntegrationTest
{
	private readonly DeleteChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteChatMessageCommandRequestBuilder _requestBuilder;
	private readonly DeleteChatMessageCommandRequest _request;

	private readonly DeleteChatMessageCommandRequestBuilder _invertedRequestBuilder;
	private readonly DeleteChatMessageCommandRequest _invertedRequest;

	public DeleteChatMessageCommandHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	[ChatMessageIdNullWithMessageData]
	[ChatMessageIdEmptyWithMessageData]
	[ChatMessageIdTooShortWithMessageData]
	[ChatMessageIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenMessageIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForMessageIdAsync(
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
	public async Task SendAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Sender.ShouldThrowChatMessageNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowChatMessageForbiddenException_WhenChatMessageForbidden()
	{
		// Arrange

		// Assert
		await Sender.ShouldThrowChatMessageForbiddenExceptionAsync(_invertedRequest, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await Sender.SendAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteInvertedChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await Sender.SendAsync(_invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedRequest, InvertedChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Sender.SendAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Sender.SendAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		await Sender.SendAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}
}
