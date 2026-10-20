using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.UpdateCurrent;

public class UpdateCurrentUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly UpdateCurrentUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserCommandRequest _request;

	private readonly UpdateCurrentUserCommandHandler _handler;

	public UpdateCurrentUserCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupUpdateAsync(_request, User, CancellationToken);
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
	public async Task Handle_ShouldCallTheServiceUpdateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneUpdateAsync(_request, CancellationToken);
	}
}
