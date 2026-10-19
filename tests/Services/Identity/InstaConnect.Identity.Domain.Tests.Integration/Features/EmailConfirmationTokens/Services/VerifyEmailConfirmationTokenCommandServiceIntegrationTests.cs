using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Services;

public class VerifyEmailConfirmationTokenCommandServiceIntegrationTests : BaseEmailConfirmationTokenDomainCommandIntegrationTest
{
	private readonly VerifyEmailConfirmationTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly VerifyEmailConfirmationTokenCommandBuilder _commandBuilder;
	private readonly VerifyEmailConfirmationTokenCommand _command;

	public VerifyEmailConfirmationTokenCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(EmailConfirmationToken);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowEmailConfirmationTokenNotFoundException_WhenEmailConfirmationTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Assert
		await Service.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserEmailAlreadyConfirmedException_WhenUserEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowEmailConfirmationTokenExpiredException_WhenEmailConfirmationTokenExpired()
	{
		// Arrange
		var updatedEmailConfirmationToken = EmailConfirmationTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedEmailConfirmationToken, CancellationToken);

		// Assert
		await Service.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Act
		await Service.VerifyAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldUpdateUser_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Fact]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenCommandIsValid()
	{
		// Act
		await Service.VerifyAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldDeleteEmailConfirmationToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenUpdatedEvents_WhenCommandIsValid()
	{
		// Act
		await Service.VerifyAsync(_command, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_command, User.EmailConfirmationTokens);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenUpdatedEvents_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task VerifyAsync_ShouldPublishEmailConfirmationTokenUpdatedEvents_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.VerifyAsync(command, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens);
	}
}
