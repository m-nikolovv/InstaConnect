namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Endpoints;

public class DeleteCurrentRefreshTokenFunctionalTests : BaseRefreshTokenPresentationCommandFunctionalTest
{
	private readonly DeleteCurrentRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly DeleteCurrentRefreshTokenApiRequest _request;

	public DeleteCurrentRefreshTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteCurrentAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[RefreshTokenValueNullData]
	[RefreshTokenValueEmptyData]
	[RefreshTokenValueTooShortData]
	[RefreshTokenValueTooLongData]
	public async Task DeleteCurrentAsync_ShouldHaveBadRequestStatusCode_WhenValueIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
	public async Task DeleteCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenValueIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForValue(request, messageTransformer);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveNotFoundStatusCode_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveRefreshTokenNotFoundProblemDetails_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyRefreshTokenNotFound(_request);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldHaveNoContentStatusCode_WhenRequestAndValueIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteCurrentRefreshToken_WhenRequestIsValid()
	{
		// Act
		await RefreshTokenApiClient.DeleteCurrentAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteCurrentRefreshToken_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await RefreshTokenApiClient.DeleteCurrentAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteCurrentRefreshToken_WhenValueIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await RefreshTokenApiClient.DeleteCurrentAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldNotReturnCookieResponse_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentCookieResponseAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldNotReturnCookieResponse_WhenIdIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentCookieResponseAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task DeleteAsync_ShouldNotReturnCookieResponse_WhenValueIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.DeleteCurrentCookieResponseAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}
}
