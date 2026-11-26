namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class GetCurrentUserDetailsByIdControllerUnitTests : BaseUserPresentationQueryUnitTest
{
	private readonly GetCurrentUserDetailsByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdApiRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdApiRequest _request;

	private readonly UserController _controller;

	public GetCurrentUserDetailsByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, UserId);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, User, CancellationToken);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetCurrentDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetCurrentDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetCurrentDetailsByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
