
namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Controllers;

public class GetCurrentUserDetailsByIdControllerIntegrationTests : BaseUserPresentationQueryIntegrationTest
{
	private readonly GetCurrentUserDetailsByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdApiRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdApiRequest _request;

	public GetCurrentUserDetailsByIdControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, UserId);
		_request = _requestBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetByIdAsync(_request, User, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetCurrentDetailsByIdAsync_ShouldThrowValidationException_WhenCurrentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetCurrentDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnOkStatusCode_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Controller.GetCurrentDetailsByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.GetCurrentDetailsByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Controller.GetCurrentDetailsByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldCacheUser_WhenRequestIsValid()
	{
		// Act
		await Controller.GetCurrentDetailsByIdAsync(_request, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(_request, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldCacheUser_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		await Controller.GetCurrentDetailsByIdAsync(request, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedUser.ShouldSatisfy(request, User);
	}
}
