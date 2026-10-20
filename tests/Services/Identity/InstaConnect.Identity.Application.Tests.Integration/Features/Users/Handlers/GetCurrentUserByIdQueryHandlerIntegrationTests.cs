using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Handlers;

public class GetCurrentUserByIdQueryHandlerIntegrationTests : BaseUserApplicationQueryIntegrationTest
{
	private readonly GetCurrentUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserByIdQueryRequestBuilder _requestBuilder;
	private readonly GetCurrentUserByIdQueryRequest _request;

	public GetCurrentUserByIdQueryHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenCurrentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User);
	}

	[Fact]
	public async Task SendAsync_ShouldCacheResponse_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var response = await ServiceScope.GetCachedAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldCacheResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var response = await ServiceScope.GetCachedAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User);
	}
}
