using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostApplicationCommandUnitTest
{
	private readonly UpdatePostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdatePostCommandRequestBuilder _requestBuilder;
	private readonly UpdatePostCommandRequest _request;

	private readonly UpdatePostCommandHandler _handler;

	public UpdatePostCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupUpdateAsync(_request, Post, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post);
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
