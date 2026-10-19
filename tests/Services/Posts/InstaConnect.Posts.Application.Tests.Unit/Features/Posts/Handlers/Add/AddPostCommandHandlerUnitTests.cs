namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.Add;

public class AddPostCommandHandlerUnitTests : BasePostApplicationCommandUnitTest
{
	private readonly AddPostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommandRequest _request;

	private readonly AddPostCommandHandler _handler;

	public AddPostCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Post.PostImages.Count);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupAddAsync(_request, Post, CancellationToken);
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
	public async Task Handle_ShouldCallTheServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
