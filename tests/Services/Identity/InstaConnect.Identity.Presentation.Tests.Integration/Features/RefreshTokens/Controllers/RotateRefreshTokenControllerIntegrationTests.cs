using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Controllers;

public class RotateRefreshTokenControllerIntegrationTests : BaseRefreshTokenPresentationCommandIntegrationTest
{
	private readonly RotateRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenApiRequest _request;

	public RotateRefreshTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task RotateAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
	public async Task RotateAsync_ShouldThrowValidationException_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForValueAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowUserEmailNotConfirmedException_WhenUserEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserEmailNotConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowRefreshTokenNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenExpiredException_WhenRefreshTokenExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedRefreshToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowRefreshTokenExpiredExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.RotateAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.RotateAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnOkStatusCode_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await Controller.RotateAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.RotateAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.RotateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await Controller.RotateAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Fact]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		await Controller.RotateAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.RotateAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(request);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Controller.RotateAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(request);
	}
}
