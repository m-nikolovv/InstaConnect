namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Handlers.Delete;

public class DeletePostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeApplicationCommandUnitTest
{
	private readonly DeletePostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentLikeCommandRequestBuilder _requestBuilder;
	private readonly DeletePostCommentLikeCommandRequest _request;

	private readonly DeletePostCommentLikeCommandHandler _handler;

	public DeletePostCommentLikeCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentLikeService);
	}

	[Fact]
	public async Task Handle_ShouldCallTheCommentLikeServiceDeleteAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentLikeService.ShouldHaveReceivedOneDeleteAsync(_request, CancellationToken);
	}
}
