namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Controllers;

public class IssueRefreshTokenControllerIntegrationTests : BaseRefreshTokenPresentationCommandIntegrationTest
{
	private readonly IssueRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenApiRequest _request;

	public IssueRefreshTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task IssueAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task IssueAsync_ShouldThrowValidationException_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForPasswordAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserInvalidDetailsAndNameIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserInvalidDetailsExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserInvalidDetailsAndPasswordIsInvalid()
	{
		// Arrange
		var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserInvalidDetailsExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserNameEmailNotConfirmedException_WhenUserNameEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.IssueAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldReturnOkStatusCode_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Controller.IssueAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.IssueAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldReturnResponse_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Controller.IssueAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request);
	}

	[Fact]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		await Controller.IssueAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Controller.IssueAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.RefreshTokens.ShouldSatisfy(request);
	}
}
