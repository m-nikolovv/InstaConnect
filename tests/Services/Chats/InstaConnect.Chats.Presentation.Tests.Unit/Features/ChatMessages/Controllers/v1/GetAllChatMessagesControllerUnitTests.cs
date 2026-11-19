namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Controllers.v1;

public class GetAllChatMessagesControllerUnitTests : BaseChatMessagePresentationQueryUnitTest
{
	private readonly GetAllChatMessagesApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatMessagesApiRequestBuilder _requestBuilder;
	private readonly GetAllChatMessagesApiRequest _request;

	private readonly ChatMessageController _controller;

	public GetAllChatMessagesControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ChatMessage, CurrentUserId);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, Chat, ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Chat, ChatMessages);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
