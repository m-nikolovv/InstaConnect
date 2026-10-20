using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.EmailConfirmationTokens.Controllers.v1;

public class AddEmailConfirmationTokenControllerUnitTests : BaseEmailConfirmationTokenPresentationCommandUnitTest
{
	private readonly AddEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenApiRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenApiRequest _request;

	private readonly EmailConfirmationTokenController _controller;

	public AddEmailConfirmationTokenControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
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
