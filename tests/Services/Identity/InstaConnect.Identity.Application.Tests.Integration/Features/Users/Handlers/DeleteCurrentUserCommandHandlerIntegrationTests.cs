using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Handlers;

public class DeleteCurrentUserCommandHandlerIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
	private readonly DeleteCurrentUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentUserCommandRequestBuilder _requestBuilder;
	private readonly DeleteCurrentUserCommandRequest _request;

	public DeleteCurrentUserCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserUserClaims_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userUserClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userUserClaims.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserUserClaims_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userUserClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userUserClaims.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserRefreshTokens_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userRefreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		userRefreshTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserRefreshTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userRefreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		userRefreshTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserForgotPasswordTokens_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userForgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		userForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserForgotPasswordTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userForgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		userForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserEmailConfirmationTokens_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userEmailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		userEmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserEmailConfirmationTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userEmailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		userEmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, User);
	}
}
