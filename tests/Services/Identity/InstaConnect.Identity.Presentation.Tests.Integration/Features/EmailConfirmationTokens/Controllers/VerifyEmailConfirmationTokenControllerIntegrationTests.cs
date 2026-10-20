using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Presentation.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.EmailConfirmationTokens.Controllers;

public class VerifyEmailConfirmationTokenControllerIntegrationTests : BaseEmailConfirmationTokenPresentationCommandIntegrationTest
{
	private readonly VerifyEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyEmailConfirmationTokenApiRequestBuilder _requestBuilder;
	private readonly VerifyEmailConfirmationTokenApiRequest _request;

	public VerifyEmailConfirmationTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	[EmailConfirmationTokenValueNullWithMessageData]
	[EmailConfirmationTokenValueEmptyWithMessageData]
	[EmailConfirmationTokenValueTooShortWithMessageData]
	[EmailConfirmationTokenValueTooLongWithMessageData]
	public async Task VerifyAsync_ShouldThrowValidationException_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForValueAsync(
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
	public async Task VerifyAsync_ShouldThrowEmailConfirmationTokenNotFoundException_WhenEmailConfirmationTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserEmailAlreadyConfirmedException_WhenUserEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowEmailConfirmationTokenExpiredException_WhenEmailConfirmationTokenExpired()
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(_request, CancellationToken);
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
	[EmailConfirmationTokenValueDifferentCaseData]
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
		await Controller.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Controller.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		await Controller.VerifyAsync(_request, CancellationToken);
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
		await Controller.VerifyAsync(request, CancellationToken);
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
		await Controller.VerifyAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		await Controller.VerifyAsync(_request, CancellationToken);
		var eventRequests = await EventClient.PublishedDeletedRangeAsync(CancellationToken);

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
		await Controller.VerifyAsync(request, CancellationToken);
		var eventRequests = await EventClient.PublishedDeletedRangeAsync(CancellationToken);

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
		await Controller.VerifyAsync(request, CancellationToken);
		var eventRequests = await EventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens);
	}
}
