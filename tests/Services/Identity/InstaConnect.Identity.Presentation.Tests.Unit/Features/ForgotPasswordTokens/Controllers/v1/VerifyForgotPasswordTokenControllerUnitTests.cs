using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.ForgotPasswordTokens.Controllers.v1;


public class VerifyForgotPasswordTokenControllerUnitTests : BaseForgotPasswordTokenPresentationCommandUnitTest
{
	private readonly VerifyForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenApiRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenApiRequest _request;

	private readonly ForgotPasswordTokenController _controller;

	public VerifyForgotPasswordTokenControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ForgotPasswordToken);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);
	}

	[Fact]
	public async Task VerifyAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.VerifyAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.VerifyAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
