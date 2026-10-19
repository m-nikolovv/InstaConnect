namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Handlers.GetById;

public class GetChatMessageByIdQueryHandlerUnitTests : BaseChatMessageApplicationQueryUnitTest
{
	private readonly GetChatMessageByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatMessageByIdQueryRequestBuilder _requestBuilder;
	private readonly GetChatMessageByIdQueryRequest _request;

	private readonly GetChatMessageByIdQueryHandler _handler;

	public GetChatMessageByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, MessageService);

		MessageService.SetupGetByIdAsync(_request, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, ChatMessage);
	}

	[Fact]
	public async Task Handle_ShouldCallTheMessageServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await MessageService.ShouldHaveReceivedOneGetByIdAsync(_request, CancellationToken);
	}
}
