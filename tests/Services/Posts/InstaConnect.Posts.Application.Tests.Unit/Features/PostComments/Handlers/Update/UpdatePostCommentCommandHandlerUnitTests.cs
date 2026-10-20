using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Handlers.Update;

public class UpdatePostCommentCommandHandlerUnitTests : BasePostCommentApplicationCommandUnitTest
{
	private readonly UpdatePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdatePostCommentCommandRequestBuilder _requestBuilder;
	private readonly UpdatePostCommentCommandRequest _request;

	private readonly UpdatePostCommentCommandHandler _handler;

	public UpdatePostCommentCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, CommentService);

		CommentService.SetupUpdateAsync(_request, PostComment, CancellationToken);
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
	public async Task Handle_ShouldCallTheCommentServiceUpdateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await CommentService.ShouldHaveReceivedOneUpdateAsync(_request, CancellationToken);
	}
}
