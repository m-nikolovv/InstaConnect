namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class GetPostByIdControllerUnitTests : BasePostPresentationQueryUnitTest
{
	private readonly GetPostByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostByIdApiRequestBuilder _requestBuilder;
	private readonly GetPostByIdApiRequest _request;

	private readonly PostController _controller;

	public GetPostByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, Post, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
