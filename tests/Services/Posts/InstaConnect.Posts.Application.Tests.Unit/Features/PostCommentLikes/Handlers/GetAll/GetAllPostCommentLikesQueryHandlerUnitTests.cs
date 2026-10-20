using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Handlers.GetAll;

public class GetAllPostCommentLikesQueryHandlerUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
	private readonly GetAllPostCommentLikesQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentLikesQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentLikesQueryRequest _request;

	private readonly GetAllPostCommentLikesQueryHandler _handler;

	public GetAllPostCommentLikesQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentLikeService);

		CommentLikeService.SetupGetAllAsync(_request, PostComment, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostComment, PostCommentLikes);
	}

	[Fact]
	public async Task Handle_ShouldCallTheCommentLikeServiceGetAllAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentLikeService.ShouldHaveReceivedOneGetAllAsync(_request, CancellationToken);
	}
}
