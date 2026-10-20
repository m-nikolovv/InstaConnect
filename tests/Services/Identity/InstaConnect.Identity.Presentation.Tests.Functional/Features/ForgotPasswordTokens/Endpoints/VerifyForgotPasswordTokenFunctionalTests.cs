using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Endpoints;

public class VerifyForgotPasswordTokenFunctionalTests : BaseForgotPasswordTokenPresentationCommandFunctionalTest
{
	private const string PasswordPropertyName = nameof(VerifyForgotPasswordTokenApiBody.Password);

	private readonly VerifyForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenApiRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenApiRequest _request;

	public VerifyForgotPasswordTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ForgotPasswordToken);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(User.ForgotPasswordTokens, CancellationToken);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task VerifyAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[ForgotPasswordTokenValueTooShortData]
	[ForgotPasswordTokenValueTooLongData]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenValueIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[ForgotPasswordTokenValueTooShortWithMessageData]
	[ForgotPasswordTokenValueTooLongWithMessageData]
	public async Task VerifyAsync_ShouldHaveBadRequestProblemDetails_WhenValueIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForValue(request, messageTransformer);
	}

	[Theory]
	[UserPasswordNullData]
	[UserPasswordEmptyData]
	[UserPasswordTooShortData]
	[UserPasswordTooLongData]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task VerifyAsync_ShouldHaveBadRequestProblemDetails_WhenPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPassword(request, messageTransformer);
	}

	[Theory]
	[UserConfirmPasswordNotEqualData]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenConfirmPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task VerifyAsync_ShouldHaveBadRequestProblemDetails_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForConfirmPassword(request, messageTransformer);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveNotFoundStatusCode_WhenForgotPasswordTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ForgotPasswordToken, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveForgotPasswordTokenNotFoundProblemDetails_WhenForgotPasswordTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ForgotPasswordToken, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyForgotPasswordTokenNotFound(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenForgotPasswordTokenExpired()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedForgotPasswordToken, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveForgotPasswordTokenExpiredProblemDetails_WhenForgotPasswordTokenExpired()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedForgotPasswordToken, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyForgotPasswordTokenExpired(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldHaveNoContentStatusCode_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Fact]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(_request, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, User.ForgotPasswordTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(request, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.ForgotPasswordTokens);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.VerifyAsync(request, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.ForgotPasswordTokens);
	}
}
