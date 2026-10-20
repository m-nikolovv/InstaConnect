using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.EmailConfirmationTokens.Controllers.v1;


public class VerifyEmailConfirmationTokenControllerUnitTests : BaseEmailConfirmationTokenPresentationCommandUnitTest
{
	private readonly VerifyEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyEmailConfirmationTokenApiRequestBuilder _requestBuilder;
	private readonly VerifyEmailConfirmationTokenApiRequest _request;

	private readonly EmailConfirmationTokenController _controller;

	public VerifyEmailConfirmationTokenControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(EmailConfirmationToken);
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
