namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Handlers.Delete;

public class DeleteUserClaimCommandHandlerUnitTests : BaseUserClaimApplicationCommandUnitTest
{
	private readonly DeleteUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserClaimCommandRequestBuilder _requestBuilder;
	private readonly DeleteUserClaimCommandRequest _request;

	private readonly DeleteUserClaimCommandHandler _handler;

	public DeleteUserClaimCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(UserClaim);
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
