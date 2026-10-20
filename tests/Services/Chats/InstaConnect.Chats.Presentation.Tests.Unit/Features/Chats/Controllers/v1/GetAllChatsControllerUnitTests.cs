using InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;
using InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Controllers.v1;

public class GetAllChatsControllerUnitTests : BaseChatPresentationQueryUnitTest
{
	private readonly GetAllChatsApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatsApiRequestBuilder _requestBuilder;
	private readonly GetAllChatsApiRequest _request;

	private readonly ChatController _controller;

	public GetAllChatsControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, ParticipantOne, Chats, CancellationToken);
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
		response.ShouldSatisfy(_request, ParticipantOne, Chats);
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
