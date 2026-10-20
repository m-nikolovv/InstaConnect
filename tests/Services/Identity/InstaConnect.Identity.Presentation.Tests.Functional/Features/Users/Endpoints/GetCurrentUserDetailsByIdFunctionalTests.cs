namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Endpoints;

public class GetCurrentUserDetailsByIdFunctionalTests : BaseUserPresentationQueryFunctionalTest
{
	private readonly GetCurrentUserDetailsByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdApiRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdApiRequest _request;

	public GetCurrentUserDetailsByIdFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.GetCurrentDetailsByIdUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await ApiClient.GetCurrentDetailsByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await ApiClient.GetCurrentDetailsByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentId(request, messageTransformer);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ApiClient.GetCurrentDetailsByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ApiClient.GetCurrentDetailsByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetCurrentDetailsByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await ApiClient.GetCurrentDetailsByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.GetCurrentDetailsByIdAsync(_request, CancellationToken);

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
		var response = await ApiClient.GetCurrentDetailsByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User);
	}

	[Fact]
	public async Task GetCurrentDetailsByIdAsync_ShouldCacheResponse_WhenRequestIsValid()
	{
		// Act
		await ApiClient.GetCurrentDetailsByIdAsync(_request, CancellationToken);
		var response = await ServiceScope.GetCachedAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetCurrentDetailsByIdAsync_ShouldCacheResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		await ApiClient.GetCurrentDetailsByIdAsync(request, CancellationToken);
		var response = await ServiceScope.GetCachedAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User);
	}
}
