namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.GetAllForUser;

public class GetAllPostsForUserQueryHandlerUnitTests : BasePostApplicationQueryUnitTest
{
	private readonly GetAllPostsForUserQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostsForUserQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostsForUserQueryRequest _request;

	private readonly GetAllPostsForUserQueryHandler _handler;

	public GetAllPostsForUserQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllForUserAsync(_request, User, Posts, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User, Posts);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceGetAllForUserAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetAllForUserAsync(_request, CancellationToken);
	}
}
