namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.GetById;

public class GetUserByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetUserByIdQueryRequestBuilder _requestBuilder;
	private readonly GetUserByIdQueryRequest _request;

	private readonly GetUserByIdQueryHandler _handler;

	public GetUserByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetByIdAsync(_request, User, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
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
