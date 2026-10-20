using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Controllers.v1;

public class GetAllUserClaimsControllerUnitTests : BaseUserClaimPresentationQueryUnitTest
{
	private readonly GetAllUserClaimsApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllUserClaimsApiRequestBuilder _requestBuilder;
	private readonly GetAllUserClaimsApiRequest _request;

	private readonly UserClaimController _controller;

	public GetAllUserClaimsControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(UserClaim);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupSendAsync(_request, User, UserClaims, CancellationToken);
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
		response.ShouldSatisfy(_request, User, UserClaims);
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
