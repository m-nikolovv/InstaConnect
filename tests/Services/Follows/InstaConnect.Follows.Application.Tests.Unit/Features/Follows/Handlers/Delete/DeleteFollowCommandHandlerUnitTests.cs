using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Handlers.Delete;

public class DeleteFollowCommandHandlerUnitTests : BaseFollowApplicationCommandUnitTest
{
	private readonly DeleteFollowCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteFollowCommandRequestBuilder _requestBuilder;
	private readonly DeleteFollowCommandRequest _request;

	private readonly DeleteFollowCommandHandler _handler;

	public DeleteFollowCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
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
