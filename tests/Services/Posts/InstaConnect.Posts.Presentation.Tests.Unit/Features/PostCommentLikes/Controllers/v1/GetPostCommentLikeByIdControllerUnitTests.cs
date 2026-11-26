namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdControllerUnitTests : BasePostCommentLikePresentationQueryUnitTest
{
	private readonly GetPostCommentLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostCommentLikeByIdApiRequestBuilder _requestBuilder;
	private readonly GetPostCommentLikeByIdApiRequest _request;

	private readonly PostCommentLikeController _controller;

	public GetPostCommentLikeByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike, UserId);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, PostCommentLike, CancellationToken);
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
		response.ShouldSatisfy(_request, PostCommentLike);
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
