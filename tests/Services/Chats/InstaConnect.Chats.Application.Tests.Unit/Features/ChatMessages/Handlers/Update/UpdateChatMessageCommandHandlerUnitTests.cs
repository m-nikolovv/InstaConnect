using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Handlers.Update;

public class UpdateChatMessageCommandHandlerUnitTests : BaseChatMessageApplicationCommandUnitTest
{
	private readonly UpdateChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateChatMessageCommandRequestBuilder _requestBuilder;
	private readonly UpdateChatMessageCommandRequest _request;

	private readonly UpdateChatMessageCommandHandler _handler;

	public UpdateChatMessageCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, MessageService);

		MessageService.SetupUpdateAsync(_request, ChatMessage, CancellationToken);
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
	public async Task Handle_ShouldCallTheMessageServiceUpdateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await MessageService.ShouldHaveReceivedOneUpdateAsync(_request, CancellationToken);
	}
}
