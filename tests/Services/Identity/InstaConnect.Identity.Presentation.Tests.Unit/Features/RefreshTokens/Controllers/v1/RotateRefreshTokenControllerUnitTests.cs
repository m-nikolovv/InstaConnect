using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Unit.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.RefreshTokens.Controllers.v1;

public class RotateRefreshTokenControllerUnitTests : BaseRefreshTokenPresentationCommandUnitTest
{
	private readonly RotateRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenApiRequest _request;

	private readonly RefreshToken _refreshToken;

	private readonly RefreshTokenController _controller;

	public RotateRefreshTokenControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();

		_refreshToken = RefreshTokenBuilderFactory.Create(User).Build();

		_controller = new(Mapper, Sender, CookieStore);

		Sender.SetupSendAsync(_request, _refreshToken, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.RotateAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.RotateAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.RotateAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldCallTheCookieStoreSet_WhenRequestIsValid()
	{
		// Act
		await _controller.RotateAsync(_request, CancellationToken);

		// Assert
		CookieStore.ShouldHaveReceivedOneSet(_request, _refreshToken);
	}
}
