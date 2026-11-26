using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Handlers.GetAllForUser;

public class GetAllPostCommentsForUserQueryHandlerUnitTests : BasePostCommentApplicationQueryUnitTest
{
	private readonly GetAllPostCommentsForUserQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentsForUserQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentsForUserQueryRequest _request;

	private readonly GetAllPostCommentsForUserQueryHandler _handler;

	public GetAllPostCommentsForUserQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentService);

		CommentService.SetupGetAllForUserAsync(_request, User, PostComments, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User, PostComments);
	}

	[Fact]
	public async Task Handle_ShouldCallTheCommentServiceGetAllForUserAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentService.ShouldHaveReceivedOneGetAllForUserAsync(_request, CancellationToken);
	}
}
