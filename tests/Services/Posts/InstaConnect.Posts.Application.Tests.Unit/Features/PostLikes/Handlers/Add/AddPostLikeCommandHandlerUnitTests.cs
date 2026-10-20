using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Handlers.Add;

public class AddPostLikeCommandHandlerUnitTests : BasePostLikeApplicationCommandUnitTest
{
	private readonly AddPostLikeCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostLikeCommandRequestBuilder _requestBuilder;
	private readonly AddPostLikeCommandRequest _request;

	private readonly AddPostLikeCommandHandler _handler;

	public AddPostLikeCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post, User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, LikeService);

		LikeService.SetupAddAsync(_request, PostLike, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, PostLike);
	}

	[Fact]
	public async Task Handle_ShouldCallTheLikeServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await LikeService.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
