namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Handlers.GetAll;

public class GetAllChatsQueryHandlerUnitTests : BaseChatApplicationQueryUnitTest
{
	private readonly GetAllChatsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllChatsQueryRequestBuilder _requestBuilder;
	private readonly GetAllChatsQueryRequest _request;

	private readonly GetAllChatsQueryHandler _handler;

	public GetAllChatsQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Chat);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllAsync(_request, ParticipantOne, Chats, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, ParticipantOne, Chats);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceGetAllAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetAllAsync(_request, CancellationToken);
	}
}
