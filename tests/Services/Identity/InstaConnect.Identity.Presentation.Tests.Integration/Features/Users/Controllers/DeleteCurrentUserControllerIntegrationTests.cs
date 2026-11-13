namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Controllers;

public class DeleteCurrentUserControllerIntegrationTests : BaseUserPresentationCommandIntegrationTest
{
	private readonly DeleteCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentUserApiRequestBuilder _requestBuilder;
	private readonly DeleteCurrentUserApiRequest _request;

	public DeleteCurrentUserControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(UserClaims, CancellationToken);
		await ServiceScope.AddRangeAsync(RefreshTokens, CancellationToken);
		await ServiceScope.AddRangeAsync(ForgotPasswordTokens, CancellationToken);
		await ServiceScope.AddRangeAsync(EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteCurrentAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.DeleteCurrentAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.DeleteCurrentAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteUserUserClaims_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var userUserClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userUserClaims.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteUserUserClaims_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var userUserClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userUserClaims.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteUserRefreshTokens_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var userRefreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		userRefreshTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteUserRefreshTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var userRefreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		userRefreshTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteUserForgotPasswordTokens_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var userForgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		userForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteUserForgotPasswordTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var userForgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		userForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteUserEmailConfirmationTokens_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var userEmailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		userEmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteUserEmailConfirmationTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var userEmailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		userEmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldPublishUserDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, User);
	}
}
