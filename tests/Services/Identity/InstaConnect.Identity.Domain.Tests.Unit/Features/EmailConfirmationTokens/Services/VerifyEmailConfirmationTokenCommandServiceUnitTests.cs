using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Services;

public class VerifyEmailConfirmationTokenCommandServiceUnitTests : BaseEmailConfirmationTokenDomainCommandUnitTest
{
	private readonly VerifyEmailConfirmationTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly VerifyEmailConfirmationTokenCommandBuilder _commandBuilder;
	private readonly VerifyEmailConfirmationTokenCommand _command;

	private readonly UserInclude _include;

	private readonly EmailConfirmationTokenCommandService _service;

	public VerifyEmailConfirmationTokenCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(EmailConfirmationToken);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithEmailConfirmationTokens().Build();

		_service = new(
			Mapper,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			Factory,
			EmailSender,
			EmailConfirmationTokenRepository);

		Repository.SetupGetByIdAsync(_command, _include, User, CancellationToken);
		EmailConfirmationTokenRepository.SetupGetByIdAsync(_command, EmailConfirmationToken, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, UnexpiredDate);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowUserEmailAlreadyConfirmedException_WhenUserEmailAlreadyConfirmed()
	{
		// Arrange
		var confirmedUser = UserBuilder.WithConfirmedEmail().Build();
		Repository.SetupGetByIdAsync(_command, _include, confirmedUser, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowEmailConfirmationTokenNotFoundException_WhenEmailConfirmationTokenNotFound()
	{
		// Arrange
		EmailConfirmationTokenRepository.RemoveGetByIdAsync(_command, EmailConfirmationToken, CancellationToken);

		// Assert
		await _service.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowEmailConfirmationTokenExpiredException_WhenEmailConfirmationTokenExpired()
	{
		// Arrange
		DateTimeProvider.SetupGetOffsetUtcNow(_command, ExpiredDate);

		// Assert
		await _service.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheEmailConfirmationTokenRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(_command);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(_command, CancellationToken);
	}
}
