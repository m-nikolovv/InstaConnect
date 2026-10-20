using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Services;

public class DeleteRefreshTokenCommandServiceUnitTests : BaseRefreshTokenDomainCommandUnitTest
{
	private readonly DeleteRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteRefreshTokenCommandBuilder _commandBuilder;
	private readonly DeleteRefreshTokenCommand _command;

	private readonly RefreshTokenCommandService _service;

	public DeleteRefreshTokenCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(RefreshToken);
		_command = _commandBuilder.Build();

		_service = new(PasswordHasher, Repository, DateTimeProvider, Factory, SessionTokenGenerator, IncludeBuilderFactory, RefreshTokenRepository);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		RefreshTokenRepository.SetupGetByIdAsync(_command, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		RefreshTokenRepository.RemoveGetByIdAsync(_command, RefreshToken, CancellationToken);

		// Assert
		await _service.ShouldThrowRefreshTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRefreshTokenRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRefreshTokenRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}
}
