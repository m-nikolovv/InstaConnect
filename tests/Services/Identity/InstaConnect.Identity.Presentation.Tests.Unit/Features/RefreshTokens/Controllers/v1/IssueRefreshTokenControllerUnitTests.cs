using InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.RefreshTokens.Controllers.v1;

public class IssueRefreshTokenControllerUnitTests : BaseRefreshTokenPresentationCommandUnitTest
{
	private readonly IssueRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenApiRequest _request;

	private readonly RefreshTokenController _controller;

	public IssueRefreshTokenControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender, CookieStore);

		Sender.SetupSendAsync(_request, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.IssueAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.IssueAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.IssueAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallTheCookieStoreSet_WhenRequestIsValid()
	{
		// Act
		await _controller.IssueAsync(_request, CancellationToken);

		// Assert
		CookieStore.ShouldHaveReceivedOneSet(_request, RefreshToken);
	}
}
