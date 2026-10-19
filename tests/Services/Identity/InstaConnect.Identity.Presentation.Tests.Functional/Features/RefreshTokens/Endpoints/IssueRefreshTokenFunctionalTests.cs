using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.RefreshTokens.Endpoints;

public class IssueRefreshTokenFunctionalTests : BaseRefreshTokenPresentationCommandFunctionalTest
{
	private readonly IssueRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenApiRequest _request;

	public IssueRefreshTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task IssueAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(request, messageTransformer);
	}

	[Theory]
	[UserPasswordNullData]
	[UserPasswordEmptyData]
	[UserPasswordTooShortData]
	[UserPasswordTooLongData]
	public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task IssueAsync_ShouldHaveBadRequestProblemDetails_WhenPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPassword(request, messageTransformer);
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenUserInvalidDetailsAndNameIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveUserInvalidDetailsProblemDetails_WhenUserInvalidDetailsAndNameIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.IssueProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserInvalidDetails(_request);
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenUserInvalidDetailsAndPasswordIsInvalid()
	{
		// Arrange
		var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveUserInvalidDetailsProblemDetails_WhenUserInvalidDetailsAndPasswordIsInvalid()
	{
		// Arrange
		var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.IssueProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserInvalidDetails(_request);
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveBadRequestStatusCode_WhenUserNameEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveUserNameEmailNotConfirmedProblemDetails_WhenUserNameEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await RefreshTokenApiClient.IssueProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameEmailNotConfirmed(_request);
	}

	[Fact]
	public async Task IssueAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldHaveOkStatusCode_WhenNameIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.IssueAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldReturnResponse_WhenNameIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Fact]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		await RefreshTokenApiClient.IssueAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldIssueRefreshToken_WhenNameIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await RefreshTokenApiClient.IssueAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnCookieResponse_WhenRequestIsValid()
	{
		// Act
		var response = await RefreshTokenApiClient.IssueCookieResponseAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, refreshToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldReturnCookieResponse_WhenNameIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await RefreshTokenApiClient.IssueCookieResponseAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, refreshToken);
	}
}
