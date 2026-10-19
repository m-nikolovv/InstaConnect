using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Services;

public class VerifyForgotPasswordTokenCommandServiceUnitTests : BaseForgotPasswordTokenDomainCommandUnitTest
{
	private readonly VerifyForgotPasswordTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly VerifyForgotPasswordTokenCommandBuilder _commandBuilder;
	private readonly VerifyForgotPasswordTokenCommand _command;

	private readonly UserInclude _include;

	private readonly ForgotPasswordTokenCommandService _service;

	public VerifyForgotPasswordTokenCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ForgotPasswordToken);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithForgotPasswordTokens().Build();

		_service = new(
			Mapper,
			PasswordHasher,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			Factory,
			EmailSender,
			ForgotPasswordTokenRepository);

		Repository.SetupGetByIdAsync(_command, _include, User, CancellationToken);
		ForgotPasswordTokenRepository.SetupGetByIdAsync(_command, ForgotPasswordToken, CancellationToken);
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
	public async Task VerifyAsync_ShouldThrowForgotPasswordTokenNotFoundException_WhenForgotPasswordTokenNotFound()
	{
		// Arrange
		ForgotPasswordTokenRepository.RemoveGetByIdAsync(_command, ForgotPasswordToken, CancellationToken);

		// Assert
		await _service.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldThrowForgotPasswordTokenExpiredException_WhenForgotPasswordTokenExpired()
	{
		// Arrange
		DateTimeProvider.SetupGetOffsetUtcNow(_command, ExpiredDate);

		// Assert
		await _service.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(_command, CancellationToken);
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
	public async Task VerifyAsync_ShouldCallTheForgotPasswordTokenRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await ForgotPasswordTokenRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
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
	public async Task VerifyAsync_ShouldCallTheForgotPasswordTokenRepositoryDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await ForgotPasswordTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, User.ForgotPasswordTokens, CancellationToken);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallThePasswordHasherHash_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		PasswordHasher.ShouldHaveReceivedOneHash(_command);
	}

	[Fact]
	public async Task VerifyAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.VerifyAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(_command, PasswordHasher, CancellationToken);
	}
}
