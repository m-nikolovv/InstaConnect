using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.DeleteCurrent;

public class DeleteCurrentUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly DeleteCurrentUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentUserCommandRequestBuilder _requestBuilder;
	private readonly DeleteCurrentUserCommandRequest _request;

	private readonly DeleteCurrentUserCommandHandler _handler;

	public DeleteCurrentUserCommandHandlerUnitTests()
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
