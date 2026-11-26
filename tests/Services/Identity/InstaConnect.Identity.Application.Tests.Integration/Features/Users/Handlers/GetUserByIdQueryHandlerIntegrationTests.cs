using InstaConnect.Identity.Application.Features.Users.Queries.GetById;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Handlers;

public class GetUserByIdQueryHandlerIntegrationTests : BaseUserApplicationQueryIntegrationTest
{
	private readonly GetUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetUserByIdQueryRequestBuilder _requestBuilder;
	private readonly GetUserByIdQueryRequest _request;

	public GetUserByIdQueryHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, CurrentUserId);
		_request = _requestBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeGetByIdAsync(_request, User, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeGetByIdAsync(_request, User, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
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
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
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
	public async Task SendAsync_ShouldCacheUser_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(_request, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldCacheUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(request, User);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldCacheUser_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(request, User);
	}
}
