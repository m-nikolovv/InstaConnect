namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Posts.Controllers.v1;

public class AddPostControllerUnitTests : BasePostPresentationCommandUnitTest
{
	private readonly AddPostApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostApiRequestBuilder _requestBuilder;
	private readonly AddPostApiRequest _request;

	private readonly PostController _controller;

	public AddPostControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, Post, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.AddAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
