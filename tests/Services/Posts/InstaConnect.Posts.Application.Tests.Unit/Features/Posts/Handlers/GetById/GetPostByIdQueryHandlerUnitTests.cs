namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.GetById;

public class GetPostByIdQueryHandlerUnitTests : BasePostApplicationQueryUnitTest
{
	private readonly GetPostByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostByIdQueryRequestBuilder _requestBuilder;
	private readonly GetPostByIdQueryRequest _request;

	private readonly GetPostByIdQueryHandler _handler;

	public GetPostByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetByIdAsync(_request, Post, CancellationToken);
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
	public async Task Handle_ShouldCallTheServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetByIdAsync(_request, CancellationToken);
	}
}
