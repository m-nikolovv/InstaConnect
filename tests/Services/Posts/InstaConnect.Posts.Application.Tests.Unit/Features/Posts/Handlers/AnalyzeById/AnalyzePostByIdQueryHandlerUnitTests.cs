namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.AnalyzeById;

public class AnalyzePostByIdQueryHandlerUnitTests : BasePostApplicationQueryUnitTest
{
	private readonly AnalyzePostByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly AnalyzePostByIdQueryRequestBuilder _requestBuilder;
	private readonly AnalyzePostByIdQueryRequest _request;

	private readonly AnalyzePostByIdQueryHandler _handler;

	public AnalyzePostByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupAnalyzeByIdAsync(_request, Post, CancellationToken);
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
	public async Task Handle_ShouldCallServiceAnalyzeByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneAnalyzeByIdAsync(_request, CancellationToken);
	}
}
