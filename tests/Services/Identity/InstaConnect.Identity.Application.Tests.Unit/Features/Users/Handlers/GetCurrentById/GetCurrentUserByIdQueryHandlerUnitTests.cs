namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.GetCurrentById;

public class GetCurrentUserByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetCurrentUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserByIdQueryRequestBuilder _requestBuilder;
	private readonly GetCurrentUserByIdQueryRequest _request;

	private readonly GetCurrentUserByIdQueryHandler _handler;

	public GetCurrentUserByIdQueryHandlerUnitTests()
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
