namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Handlers.Add;

public class AddPostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeApplicationCommandUnitTest
{
	private readonly AddPostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentLikeCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommentLikeCommandRequest _request;

	private readonly AddPostCommentLikeCommandHandler _handler;

	public AddPostCommentLikeCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment, User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentLikeService);

		CommentLikeService.SetupAddAsync(_request, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostCommentLike);
	}

	[Fact]
	public async Task Handle_ShouldCallTheCommentLikeServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentLikeService.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
