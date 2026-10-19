namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Handlers.Add;

public class AddPostCommentCommandHandlerUnitTests : BasePostCommentApplicationCommandUnitTest
{
	private readonly AddPostCommentCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommentCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommentCommandRequest _request;

	private readonly AddPostCommentCommandHandler _handler;

	public AddPostCommentCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post, User, PostComment.PostCommentImages.Count);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentService);

		CommentService.SetupAddAsync(_request, PostComment, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostComment);
	}

	[Fact]
	public async Task Handle_ShouldCallTheCommentServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentService.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
