namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class AnalyzePostByIdControllerUnitTests : BasePostPresentationQueryUnitTest
{
	private readonly AnalyzePostByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AnalyzePostByIdApiRequestBuilder _requestBuilder;
	private readonly AnalyzePostByIdApiRequest _request;

	private readonly PostController _controller;

	public AnalyzePostByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, Post, CancellationToken);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AnalyzeByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AnalyzeByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.AnalyzeByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
