using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Handlers.DeleteCurrent;

public class DeleteCurrentRefreshTokenCommandHandlerUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly DeleteCurrentRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly DeleteCurrentRefreshTokenCommandRequest _request;

	private readonly DeleteCurrentRefreshTokenCommandHandler _handler;

	public DeleteCurrentRefreshTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceDeleteAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneDeleteAsync(_request, CancellationToken);
	}
}
