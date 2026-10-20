using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Endpoints;

public class DeleteChatMessageFunctionalTests : BaseChatMessagePresentationCommandFunctionalTest
{
	private readonly DeleteChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteChatMessageApiRequestBuilder _requestBuilder;
	private readonly DeleteChatMessageApiRequest _request;

	private readonly DeleteChatMessageApiRequestBuilder _invertedRequestBuilder;
	private readonly DeleteChatMessageApiRequest _invertedRequest;

	public DeleteChatMessageFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantOneId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(request, messageTransformer);
	}

	[Theory]
	[ChatMessageIdTooShortData]
	[ChatMessageIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenMessageIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageIdTooShortWithMessageData]
	[ChatMessageIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenMessageIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForMessageId(request, messageTransformer);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveChatNotFoundProblemDetails_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveChatMessageNotFoundProblemDetails_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatMessageNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenChatMessageForbidden()
	{
		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveChatMessageForbiddenProblemDetails_WhenChatMessageForbidden()
	{
		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyChatMessageForbidden(_invertedRequest);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
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
		await ApiClient.DeleteAsync(request, CancellationToken);
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
		await ApiClient.DeleteAsync(request, CancellationToken);
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
		await ApiClient.DeleteAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
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
		await ApiClient.DeleteAsync(request, CancellationToken);
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
		await ApiClient.DeleteAsync(request, CancellationToken);
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
		await ApiClient.DeleteAsync(request, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, ChatMessage);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveInvertedNoContentStatusCode_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveInvertedNoContentStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveInvertedNoContentStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveInvertedNoContentStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await ApiClient.DeleteAsync(_invertedRequest, CancellationToken);
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
		await ApiClient.DeleteAsync(invertedRequest, CancellationToken);
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
		await ApiClient.DeleteAsync(invertedRequest, CancellationToken);
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
		await ApiClient.DeleteAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await ApiClient.DeleteAsync(_invertedRequest, CancellationToken);
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
		await ApiClient.DeleteAsync(invertedRequest, CancellationToken);
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
		await ApiClient.DeleteAsync(invertedRequest, CancellationToken);
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
		await ApiClient.DeleteAsync(invertedRequest, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, InvertedChatMessage);
	}
}
