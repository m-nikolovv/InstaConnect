namespace InstaConnect.Follows.Application.Tests.Unit.Features.Users.Handlers.Update;

public class UpdateUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateUserCommandRequest _request;

	private readonly UpdateUserCommandHandler _handler;

	public UpdateUserCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, UserService);

		UserService.SetupUpdateAsync(_request, User, CancellationToken);
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
	public async Task Handle_ShouldCallTheUserServiceUpdateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await UserService.ShouldHaveReceivedOneUpdateAsync(_request, CancellationToken);
	}
}
