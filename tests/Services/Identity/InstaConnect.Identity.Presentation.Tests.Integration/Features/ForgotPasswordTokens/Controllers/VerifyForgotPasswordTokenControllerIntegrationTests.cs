using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.ForgotPasswordTokens.Controllers;

public class VerifyForgotPasswordTokenControllerIntegrationTests : BaseForgotPasswordTokenPresentationCommandIntegrationTest
{
	private const string PasswordPropertyName = nameof(VerifyForgotPasswordTokenApiBody.Password);

	private readonly VerifyForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenApiRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenApiRequest _request;

	public VerifyForgotPasswordTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task VerifyAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[ForgotPasswordTokenValueNullWithMessageData]
	[ForgotPasswordTokenValueEmptyWithMessageData]
	[ForgotPasswordTokenValueTooShortWithMessageData]
	[ForgotPasswordTokenValueTooLongWithMessageData]
	public async Task VerifyAsync_ShouldThrowValidationException_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForValueAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task VerifyAsync_ShouldThrowValidationException_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForPasswordAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task VerifyAsync_ShouldThrowValidationException_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowForgotPasswordTokenNotFoundException_WhenForgotPasswordTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ForgotPasswordToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowForgotPasswordTokenExpiredException_WhenForgotPasswordTokenExpired()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedForgotPasswordToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.VerifyAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldReturnNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.VerifyAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldReturnNoContentStatusCode_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await Controller.VerifyAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		await Controller.VerifyAsync(_request, CancellationToken);
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
		await Controller.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request, PasswordHasher);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Controller.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request, PasswordHasher);
	}

	[Fact]
	public async Task VerifyAsync_ShouldDeleteForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		await Controller.VerifyAsync(_request, CancellationToken);
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
		await Controller.VerifyAsync(request, CancellationToken);
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
		await Controller.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task VerifyAsync_ShouldPublishForgotPasswordTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await Controller.VerifyAsync(_request, CancellationToken);
		var eventRequests = await EventClient.PublishedDeletedRangeAsync(CancellationToken);

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
		await Controller.VerifyAsync(request, CancellationToken);
		var eventRequests = await EventClient.PublishedDeletedRangeAsync(CancellationToken);

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
		await Controller.VerifyAsync(request, CancellationToken);
		var eventRequests = await EventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.ForgotPasswordTokens);
	}
}
