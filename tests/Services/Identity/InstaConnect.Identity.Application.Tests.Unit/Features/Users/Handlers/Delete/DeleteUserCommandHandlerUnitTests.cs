using InstaConnect.Identity.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.Delete;

public class DeleteUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserCommandRequestBuilder _requestBuilder;
	private readonly DeleteUserCommandRequest _request;

	private readonly DeleteUserCommandHandler _handler;

	public DeleteUserCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceDeleteAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneDeleteAsync(_request, CancellationToken);
	}
}
