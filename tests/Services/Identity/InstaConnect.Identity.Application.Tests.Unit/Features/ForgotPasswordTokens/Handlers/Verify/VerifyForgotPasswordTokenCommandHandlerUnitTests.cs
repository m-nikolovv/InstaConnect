using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Handlers.Verify;

public class VerifyForgotPasswordTokenCommandHandlerUnitTests : BaseForgotPasswordTokenApplicationCommandUnitTest
{
	private readonly VerifyForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenCommandRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenCommandRequest _request;

	private readonly VerifyForgotPasswordTokenCommandHandler _handler;

	public VerifyForgotPasswordTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ForgotPasswordToken);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceVerifyAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneVerifyAsync(_request, CancellationToken);
	}
}
