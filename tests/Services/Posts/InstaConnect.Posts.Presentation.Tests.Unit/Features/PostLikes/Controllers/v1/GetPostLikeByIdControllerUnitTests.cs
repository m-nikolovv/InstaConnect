namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdControllerUnitTests : BasePostLikePresentationQueryUnitTest
{
	private readonly GetPostLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostLikeByIdApiRequestBuilder _requestBuilder;
	private readonly GetPostLikeByIdApiRequest _request;

	private readonly PostLikeController _controller;

	public GetPostLikeByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike, UserId);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, PostLike, CancellationToken);
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
		response.ShouldSatisfy(_request, PostLike);
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
