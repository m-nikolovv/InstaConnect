using InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;
using InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Controllers.v1;

public class AddChatControllerUnitTests : BaseChatPresentationCommandUnitTest
{
	private readonly AddChatApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddChatApiRequestBuilder _requestBuilder;
	private readonly AddChatApiRequest _request;

	private readonly ChatController _controller;

	public AddChatControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, Chat, CancellationToken);
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
		response.ShouldSatisfy(_request, Chat);
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
