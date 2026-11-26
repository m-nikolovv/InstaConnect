namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesForUserControllerUnitTests : BasePostLikePresentationQueryUnitTest
{
	private readonly GetAllPostLikesForUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostLikesForUserApiRequestBuilder _requestBuilder;
	private readonly GetAllPostLikesForUserApiRequest _request;

	private readonly UserPostLikeController _controller;

	public GetAllPostLikesForUserControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike, UserId);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, User, PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User, PostLikes);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
