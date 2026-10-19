namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Handlers.Verify;

public class VerifyEmailConfirmationTokenCommandHandlerUnitTests : BaseEmailConfirmationTokenApplicationCommandUnitTest
{
	private readonly VerifyEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
	private readonly VerifyEmailConfirmationTokenCommandRequest _request;

	private readonly VerifyEmailConfirmationTokenCommandHandler _handler;

	public VerifyEmailConfirmationTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(EmailConfirmationToken);
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
