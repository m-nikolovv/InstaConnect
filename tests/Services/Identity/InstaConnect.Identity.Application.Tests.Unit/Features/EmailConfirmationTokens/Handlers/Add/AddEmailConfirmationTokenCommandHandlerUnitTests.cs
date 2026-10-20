using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Handlers.Add;

public class AddEmailConfirmationTokenCommandHandlerUnitTests : BaseEmailConfirmationTokenApplicationCommandUnitTest
{
	private readonly AddEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenCommandRequest _request;

	private readonly AddEmailConfirmationTokenCommandHandler _handler;

	public AddEmailConfirmationTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupAddAsync(_request, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneAddAsync(_request, CancellationToken);
	}
}
