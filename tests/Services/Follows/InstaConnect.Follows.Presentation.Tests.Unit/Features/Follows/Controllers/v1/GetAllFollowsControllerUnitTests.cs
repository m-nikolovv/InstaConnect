using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Follows.Controllers.v1;

public class GetAllFollowsControllerUnitTests : BaseFollowPresentationQueryUnitTest
{
	private readonly GetAllFollowsApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllFollowsApiRequestBuilder _requestBuilder;
	private readonly GetAllFollowsApiRequest _request;

	private readonly FollowController _controller;

	public GetAllFollowsControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, Follower, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Follower, Follows);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetAllAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
