using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Handlers.Delete;

public class DeleteChatMessageCommandHandlerUnitTests : BaseChatMessageApplicationCommandUnitTest
{
	private readonly DeleteChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteChatMessageCommandRequestBuilder _requestBuilder;
	private readonly DeleteChatMessageCommandRequest _request;

	private readonly DeleteChatMessageCommandHandler _handler;

	public DeleteChatMessageCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, MessageService);
	}

	[Fact]
	public async Task Handle_ShouldCallTheMessageServiceDeleteAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await MessageService.ShouldHaveReceivedOneDeleteAsync(_request, CancellationToken);
	}
}
