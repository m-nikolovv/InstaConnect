using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Handlers.Add;

public class AddFollowCommandHandlerUnitTests : BaseFollowApplicationCommandUnitTest
{
	private readonly AddFollowCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowCommandRequestBuilder _requestBuilder;
	private readonly AddFollowCommandRequest _request;

	private readonly AddFollowCommandHandler _handler;

	public AddFollowCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follower, Following);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupAddAsync(_request, Follow, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Follow);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
