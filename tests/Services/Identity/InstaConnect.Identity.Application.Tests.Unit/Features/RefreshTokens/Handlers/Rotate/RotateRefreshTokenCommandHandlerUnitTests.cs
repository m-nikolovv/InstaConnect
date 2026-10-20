using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Handlers.Rotate;

public class RotateRefreshTokenCommandHandlerUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly RotateRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenCommandRequest _request;

	private readonly RefreshToken _refreshToken;

	private readonly RotateRefreshTokenCommandHandler _handler;

	public RotateRefreshTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();

		_refreshToken = RefreshTokenBuilderFactory.Create(User).Build();

		_handler = new(Mapper, Service);

		Service.SetupRotateAsync(_request, _refreshToken, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, _refreshToken);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceRotateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneRotateAsync(_request, CancellationToken);
	}
}
