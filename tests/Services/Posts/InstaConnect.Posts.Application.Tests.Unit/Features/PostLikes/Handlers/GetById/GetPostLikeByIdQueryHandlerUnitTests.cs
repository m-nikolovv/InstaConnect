using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Handlers.GetById;

public class GetPostLikeByIdQueryHandlerUnitTests : BasePostLikeApplicationQueryUnitTest
{
	private readonly GetPostLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetPostLikeByIdQueryRequestBuilder _requestBuilder;
	private readonly GetPostLikeByIdQueryRequest _request;

	private readonly GetPostLikeByIdQueryHandler _handler;

	public GetPostLikeByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostLike);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, LikeService);

		LikeService.SetupGetByIdAsync(_request, PostLike, CancellationToken);
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
	public async Task Handle_ShouldCallTheLikeServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await LikeService.ShouldHaveReceivedOneGetByIdAsync(_request, CancellationToken);
	}
}
