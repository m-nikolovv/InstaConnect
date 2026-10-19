namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.GetAll;

public class GetAllUsersQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetAllUsersQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllUsersQueryRequestBuilder _requestBuilder;
	private readonly GetAllUsersQueryRequest _request;

	private readonly GetAllUsersQueryHandler _handler;

	public GetAllUsersQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllAsync(_request, Users, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Users);
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
