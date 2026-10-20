using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Handlers.GetAllForFollowing;

public class GetAllFollowsForFollowingQueryHandlerUnitTests : BaseFollowApplicationQueryUnitTest
{
	private readonly GetAllFollowsForFollowingQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllFollowsForFollowingQueryRequestBuilder _requestBuilder;
	private readonly GetAllFollowsForFollowingQueryRequest _request;

	private readonly GetAllFollowsForFollowingQueryHandler _handler;

	public GetAllFollowsForFollowingQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetAllForFollowingAsync(_request, Following, Follows, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Following, Follows);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceGetAllForFollowingAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetAllForFollowingAsync(_request, CancellationToken);
	}
}
