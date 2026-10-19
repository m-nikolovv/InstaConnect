namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Handlers.GetAll;

public class GetAllFollowsQueryHandlerUnitTests : BaseFollowApplicationQueryUnitTest
{
	private readonly GetAllFollowsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllFollowsQueryRequestBuilder _requestBuilder;
	private readonly GetAllFollowsQueryRequest _request;

	private readonly GetAllFollowsQueryHandler _handler;

	public GetAllFollowsQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllAsync(_request, Follower, Follows, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Follower, Follows);
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
