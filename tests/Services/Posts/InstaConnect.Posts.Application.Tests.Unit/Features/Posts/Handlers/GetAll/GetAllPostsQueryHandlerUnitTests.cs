using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.GetAll;

public class GetAllPostsQueryHandlerUnitTests : BasePostApplicationQueryUnitTest
{
	private readonly GetAllPostsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostsQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostsQueryRequest _request;

	private readonly GetAllPostsQueryHandler _handler;

	public GetAllPostsQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllAsync(_request, Posts, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Posts);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceGetAllAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetAllAsync(_request, CancellationToken);
	}
}
