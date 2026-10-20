using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Endpoints;

public class RotateRefreshTokenFunctionalTests : BaseRefreshTokenPresentationCommandFunctionalTest
{
	private readonly RotateRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenApiRequest _request;

	public RotateRefreshTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task RotateAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[RefreshTokenValueNullData]
	[RefreshTokenValueEmptyData]
	[RefreshTokenValueTooShortData]
	[RefreshTokenValueTooLongData]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenValueIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
	public async Task RotateAsync_ShouldHaveBadRequestProblemDetails_WhenValueIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForValue(request, messageTransformer);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveUserEmailNotConfirmedProblemDetails_WhenUserEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailNotConfirmed(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveNotFoundStatusCode_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveRefreshTokenNotFoundProblemDetails_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyRefreshTokenNotFound(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveBadRequestStatusCode_WhenRefreshTokenExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedRefreshToken, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveRefreshTokenExpiredProblemDetails_WhenRefreshTokenExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedRefreshToken, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.RotateProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyRefreshTokenExpired(_request);
	}

	[Fact]
	public async Task RotateAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldHaveOkStatusCode_WhenRequestAndValueAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.RotateAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestAndValueAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Fact]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		await RefreshTokenApiClient.RotateAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await RefreshTokenApiClient.RotateAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(request);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestAndValueAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await RefreshTokenApiClient.RotateAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnCookieResponse_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.RotateCookieResponseAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, refreshToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnCookieResponse_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateCookieResponseAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, refreshToken);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnCookieResponse_WhenRequestAndValueAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.RotateCookieResponseAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, refreshToken);
	}
}
