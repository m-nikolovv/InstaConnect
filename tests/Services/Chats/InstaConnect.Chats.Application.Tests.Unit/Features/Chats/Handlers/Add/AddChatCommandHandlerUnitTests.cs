namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Handlers.Add;

public class AddChatCommandHandlerUnitTests : BaseChatApplicationCommandUnitTest
{
	private readonly AddChatCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatCommandRequestBuilder _requestBuilder;
	private readonly AddChatCommandRequest _request;

	private readonly AddChatCommandHandler _handler;

	public AddChatCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupAddAsync(_request, Chat, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Chat);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
