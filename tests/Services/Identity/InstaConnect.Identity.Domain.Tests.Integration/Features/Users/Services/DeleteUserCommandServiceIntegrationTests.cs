using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Services;

public class DeleteUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly DeleteUserCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserCommandBuilder _commandBuilder;
	private readonly DeleteUserCommand _command;

	public DeleteUserCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(UserClaims, CancellationToken);
		await ServiceScope.AddRangeAsync(RefreshTokens, CancellationToken);
		await ServiceScope.AddRangeAsync(ForgotPasswordTokens, CancellationToken);
		await ServiceScope.AddRangeAsync(EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserUserClaims_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var userUserClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userUserClaims.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserUserClaims_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var userUserClaims = await ServiceScope.GetByIdRangeAsync(UserUserClaimIds, CancellationToken);

		// Assert
		userUserClaims.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserRefreshTokens_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var userRefreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		userRefreshTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserRefreshTokens_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var userRefreshTokens = await ServiceScope.GetByIdRangeAsync(UserRefreshTokenIds, CancellationToken);

		// Assert
		userRefreshTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserForgotPasswordTokens_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var userForgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		userForgotPasswordTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserForgotPasswordTokens_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var userForgotPasswordTokens = await ServiceScope.GetByIdRangeAsync(UserForgotPasswordTokenIds, CancellationToken);

		// Assert
		userForgotPasswordTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserEmailConfirmationTokens_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var userEmailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		userEmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserEmailConfirmationTokens_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var userEmailConfirmationTokens = await ServiceScope.GetByIdRangeAsync(UserEmailConfirmationTokenIds, CancellationToken);

		// Assert
		userEmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishUserDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishUserDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, User);
	}
}
