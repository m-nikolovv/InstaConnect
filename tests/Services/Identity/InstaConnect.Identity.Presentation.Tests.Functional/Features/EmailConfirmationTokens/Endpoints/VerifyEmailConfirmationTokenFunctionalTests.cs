using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Endpoints;

public class VerifyEmailConfirmationTokenFunctionalTests : BaseEmailConfirmationTokenPresentationCommandFunctionalTest
{
	private readonly VerifyEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyEmailConfirmationTokenApiRequestBuilder _requestBuilder;
	private readonly VerifyEmailConfirmationTokenApiRequest _request;

	public VerifyEmailConfirmationTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(EmailConfirmationToken);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(User.EmailConfirmationTokens, CancellationToken);
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
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

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
		var response = await EmailConfirmationTokenApiClient.VerifyProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[EmailConfirmationTokenValueTooShortData]
	[EmailConfirmationTokenValueTooLongData]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenValueIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[EmailConfirmationTokenValueTooShortWithMessageData]
	[EmailConfirmationTokenValueTooLongWithMessageData]
	public async Task VerifyAsync_ShouldHaveBadRequestProblemDetails_WhenValueIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForValue(request, messageTransformer);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveUserEmailAlreadyConfirmedProblemDetails_WhenUserEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyConfirmed(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveNotFoundStatusCode_WhenEmailConfirmationTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveEmailConfirmationTokenNotFoundProblemDetails_WhenEmailConfirmationTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyEmailConfirmationTokenNotFound(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveBadRequestStatusCode_WhenEmailConfirmationTokenExpired()
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveEmailConfirmationTokenExpiredProblemDetails_WhenEmailConfirmationTokenExpired()
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyEmailConfirmationTokenExpired(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(_request, CancellationToken);

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
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldHaveNoContentStatusCode_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await EmailConfirmationTokenApiClient.VerifyStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(_request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, User.EmailConfirmationTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.VerifyAsync(request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens);
	}
}
