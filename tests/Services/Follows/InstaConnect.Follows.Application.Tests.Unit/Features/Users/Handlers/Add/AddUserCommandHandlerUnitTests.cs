using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Users.Handlers.Add;

public class AddUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserCommandRequestBuilder _requestBuilder;
	private readonly AddUserCommandRequest _request;

	private readonly AddUserCommandHandler _handler;

	public AddUserCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create();
		_request = _requestBuilder.Build();

		_handler = new(Mapper, UserService);

		UserService.SetupAddAsync(_request, User, CancellationToken);
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
	public async Task Handle_ShouldCallTheUserServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await UserService.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
