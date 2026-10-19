namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Endpoints;

public class UpdateChatMessageFunctionalTests : BaseChatMessagePresentationCommandFunctionalTest
{
	private readonly UpdateChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateChatMessageApiRequestBuilder _requestBuilder;
	private readonly UpdateChatMessageApiRequest _request;

	private readonly UpdateChatMessageApiRequestBuilder _invertedRequestBuilder;
	private readonly UpdateChatMessageApiRequest _invertedRequest;

	public UpdateChatMessageFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
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
	public async Task UpdateAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.UpdateUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantOneId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(request, messageTransformer);
	}

	[Theory]
	[ChatMessageIdTooShortData]
	[ChatMessageIdTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenMessageIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageIdTooShortWithMessageData]
	[ChatMessageIdTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenMessageIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForMessageId(request, messageTransformer);
	}

	[Theory]
	[ChatMessageContentNullData]
	[ChatMessageContentEmptyData]
	[ChatMessageContentTooShortData]
	[ChatMessageContentTooLongData]
	public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
	public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForContent(request, messageTransformer);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveChatNotFoundProblemDetails_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveChatMessageNotFoundProblemDetails_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatMessageNotFound(_request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveForbiddenStatusCode_WhenChatMessageForbidden()
	{
		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveChatMessageForbiddenProblemDetails_WhenChatMessageForbidden()
	{
		// Act
		var response = await ApiClient.UpdateProblemDetailsAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyChatMessageForbidden(_invertedRequest);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ChatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateAsync_ShouldHaveInvertedResponse_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.UpdateAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedRequest, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldHaveInvertedResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, ChatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.UpdateAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(_invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await ApiClient.UpdateAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}
}
