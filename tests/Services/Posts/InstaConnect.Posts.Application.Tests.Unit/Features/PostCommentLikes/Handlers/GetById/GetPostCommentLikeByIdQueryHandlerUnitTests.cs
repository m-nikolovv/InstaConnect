using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Handlers.GetById;

public class GetPostCommentLikeByIdQueryHandlerUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
	private readonly GetPostCommentLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostCommentLikeByIdQueryRequestBuilder _requestBuilder;
	private readonly GetPostCommentLikeByIdQueryRequest _request;

	private readonly GetPostCommentLikeByIdQueryHandler _handler;

	public GetPostCommentLikeByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentLikeService);

		CommentLikeService.SetupGetByIdAsync(_request, PostCommentLike, CancellationToken);
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
	public async Task Handle_ShouldCallTheCommentLikeServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentLikeService.ShouldHaveReceivedOneGetByIdAsync(_request, CancellationToken);
	}
}
