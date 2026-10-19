using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Endpoints;

public class AddChatMessageFunctionalTests : BaseChatMessagePresentationCommandFunctionalTest
{
	private readonly AddChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageApiRequestBuilder _requestBuilder;
	private readonly AddChatMessageApiRequest _request;

	private readonly AddChatMessageApiRequestBuilder _invertedRequestBuilder;
	private readonly AddChatMessageApiRequest _invertedRequest;

	public AddChatMessageFunctionalTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat, ChatMessage.ChatMessageImages.Count);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(Chat, ChatMessage.ChatMessageImages.Count).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedRequest = _invertedRequestBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantOneIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantOneId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenParticipantTwoIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForParticipantTwoId(request, messageTransformer);
	}

	[Theory]
	[ChatMessageContentNullData]
	[ChatMessageContentEmptyData]
	[ChatMessageContentTooShortData]
	[ChatMessageContentTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ChatMessageContentNullWithMessageData]
	[ChatMessageContentEmptyWithMessageData]
	[ChatMessageContentTooShortWithMessageData]
	[ChatMessageContentTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithContent(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForContent(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveChatNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyChatNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddChatMessage_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(request, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddStatusCodeAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldHaveInvertedOkStatusCode_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedRequest, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(_invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedRequest);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedRequest, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(request);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(_invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenRequestAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenRequestAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedRequest);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenRequestAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithImages(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(invertedRequest, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldBeEmpty();
	}
}
