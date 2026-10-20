using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Controllers.v1;

public class AddUserClaimControllerUnitTests : BaseUserClaimPresentationCommandUnitTest
{
	private readonly AddUserClaimApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserClaimApiRequestBuilder _requestBuilder;
	private readonly AddUserClaimApiRequest _request;

	private readonly UserClaimController _controller;

	public AddUserClaimControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, UserClaim);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.AddAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
