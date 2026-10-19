namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Handlers;

public class GetChatMessageByIdQueryHandlerIntegrationTests : BaseChatMessageApplicationQueryIntegrationTest
{
	private readonly GetChatMessageByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatMessageByIdQueryRequestBuilder _requestBuilder;
	private readonly GetChatMessageByIdQueryRequest _request;

	private readonly GetChatMessageByIdQueryRequestBuilder _invertedRequestBuilder;
	private readonly GetChatMessageByIdQueryRequest _invertedRequest;

	public GetChatMessageByIdQueryHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_invertedRequestBuilder = _requestBuilderFactory.Create(ChatMessage).WithCurrentUserId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
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

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
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
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, ChatMessage);
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

		// Assert
		response.ShouldSatisfy(request, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, ChatMessage);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(_invertedRequest, ChatMessage);
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

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnInvertedResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedRequest = _invertedRequestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(invertedRequest, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(invertedRequest, ChatMessage);
	}
}
