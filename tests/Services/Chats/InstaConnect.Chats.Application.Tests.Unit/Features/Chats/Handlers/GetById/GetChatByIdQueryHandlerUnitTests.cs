namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Handlers.GetById;

public class GetChatByIdQueryHandlerUnitTests : BaseChatApplicationQueryUnitTest
{
	private readonly GetChatByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetChatByIdQueryRequestBuilder _requestBuilder;
	private readonly GetChatByIdQueryRequest _request;

	private readonly GetChatByIdQueryHandler _handler;

	public GetChatByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetByIdAsync(_request, Chat, CancellationToken);
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
	public async Task Handle_ShouldCallTheServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetByIdAsync(_request, CancellationToken);
	}
}
