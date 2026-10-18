namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Handlers.Add;

public class AddChatMessageCommandHandlerUnitTests : BaseChatMessageApplicationCommandUnitTest
{
	private readonly AddChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageCommandRequestBuilder _requestBuilder;
	private readonly AddChatMessageCommandRequest _request;

	private readonly AddChatMessageCommandHandler _handler;

	public AddChatMessageCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat, ChatMessage.ChatMessageImages.Count);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentService);

		CommentService.SetupAddAsync(_request, ChatMessage, CancellationToken);
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
	public async Task Handle_ShouldCallCommentServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentService.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
