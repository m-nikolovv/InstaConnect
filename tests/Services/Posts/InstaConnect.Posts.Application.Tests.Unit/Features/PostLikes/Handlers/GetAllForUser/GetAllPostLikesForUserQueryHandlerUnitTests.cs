namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Handlers.GetAllForUser;

public class GetAllPostLikesForUserQueryHandlerUnitTests : BasePostLikeApplicationQueryUnitTest
{
	private readonly GetAllPostLikesForUserQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostLikesForUserQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostLikesForUserQueryRequest _request;

	private readonly GetAllPostLikesForUserQueryHandler _handler;

	public GetAllPostLikesForUserQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, LikeService);

		LikeService.SetupGetAllForUserAsync(_request, User, PostLikes, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User, PostLikes);
	}

	[Fact]
	public async Task Handle_ShouldCallTheLikeServiceGetAllForUserAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await LikeService.ShouldHaveReceivedOneGetAllForUserAsync(_request, CancellationToken);
	}
}
