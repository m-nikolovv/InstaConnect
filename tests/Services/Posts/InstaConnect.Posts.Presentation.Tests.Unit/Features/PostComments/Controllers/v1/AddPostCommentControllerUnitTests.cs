namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostComments.Controllers.v1;

public class AddPostCommentControllerUnitTests : BasePostCommentPresentationCommandUnitTest
{
	private readonly AddPostCommentApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentApiRequestBuilder _requestBuilder;
	private readonly AddPostCommentApiRequest _request;

	private readonly PostCommentController _controller;

	public AddPostCommentControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post, User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, PostComment, CancellationToken);
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
		response.ShouldSatisfy(_request, PostComment);
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
