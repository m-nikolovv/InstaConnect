using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Handlers.Issue;

public class IssueRefreshTokenCommandHandlerUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly IssueRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenCommandRequest _request;

	private readonly IssueRefreshTokenCommandHandler _handler;

	public IssueRefreshTokenCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupIssueAsync(_request, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, RefreshToken);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceIssueAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneIssueAsync(_request, CancellationToken);
	}
}
