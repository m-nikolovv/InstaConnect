namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class GetUserByIdControllerUnitTests : BaseUserPresentationQueryUnitTest
{
	private readonly GetUserByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetUserByIdApiRequestBuilder _requestBuilder;
	private readonly GetUserByIdApiRequest _request;

	private readonly UserController _controller;

	public GetUserByIdControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, CurrentUserId);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.GetByIdAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
