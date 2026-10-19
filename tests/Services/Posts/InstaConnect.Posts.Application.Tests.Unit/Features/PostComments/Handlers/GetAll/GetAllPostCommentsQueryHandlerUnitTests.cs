namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Handlers.GetAll;

public class GetAllPostCommentsQueryHandlerUnitTests : BasePostCommentApplicationQueryUnitTest
{
	private readonly GetAllPostCommentsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentsQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentsQueryRequest _request;

	private readonly GetAllPostCommentsQueryHandler _handler;

	public GetAllPostCommentsQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentService);

		CommentService.SetupGetAllAsync(_request, Post, PostComments, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post, PostComments);
	}

	[Fact]
	public async Task Handle_ShouldCallTheCommentServiceGetAllAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentService.ShouldHaveReceivedOneGetAllAsync(_request, CancellationToken);
	}
}
