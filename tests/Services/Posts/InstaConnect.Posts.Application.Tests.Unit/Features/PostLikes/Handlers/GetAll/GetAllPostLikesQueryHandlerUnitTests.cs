namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Handlers.GetAll;

public class GetAllPostLikesQueryHandlerUnitTests : BasePostLikeApplicationQueryUnitTest
{
	private readonly GetAllPostLikesQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostLikesQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostLikesQueryRequest _request;

	private readonly GetAllPostLikesQueryHandler _handler;

	public GetAllPostLikesQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, LikeService);

		LikeService.SetupGetAllAsync(_request, Post, PostLikes, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post, PostLikes);
	}

	[Fact]
	public async Task Handle_ShouldCallTheLikeServiceGetAllAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await LikeService.ShouldHaveReceivedOneGetAllAsync(_request, CancellationToken);
	}
}
