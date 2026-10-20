using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryHandlerUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetCurrentUserDetailsByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdQueryRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdQueryRequest _request;

	private readonly GetCurrentUserDetailsByIdQueryHandler _handler;

	public GetCurrentUserDetailsByIdQueryHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupGetByIdAsync(_request, User, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Fact]
	public async Task Handle_ShouldCallTheServiceGetByIdAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldHaveReceivedOneGetByIdAsync(_request, CancellationToken);
	}
}
