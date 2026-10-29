namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Controllers.v1;

public class AddChatMessageControllerUnitTests : BaseChatMessagePresentationCommandUnitTest
{
	private readonly AddChatMessageApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatMessageApiRequestBuilder _requestBuilder;
	private readonly AddChatMessageApiRequest _request;

	private readonly ChatMessageController _controller;

	public AddChatMessageControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.AddAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
