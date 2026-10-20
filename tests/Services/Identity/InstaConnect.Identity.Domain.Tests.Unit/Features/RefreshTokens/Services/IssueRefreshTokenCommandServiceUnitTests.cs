using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Services;

public class IssueRefreshTokenCommandServiceUnitTests : BaseRefreshTokenDomainCommandUnitTest
{
	private readonly IssueRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly IssueRefreshTokenCommandBuilder _commandBuilder;
	private readonly IssueRefreshTokenCommand _command;

	private readonly UserInclude _include;

	private readonly RefreshTokenCommandService _service;

	public IssueRefreshTokenCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User, Password);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUserClaims().Build();

		_service = new(PasswordHasher, Repository, DateTimeProvider, Factory, SessionTokenGenerator, IncludeBuilderFactory, RefreshTokenRepository);

		Repository.SetupGetByNameAsync(_command, _include, User, CancellationToken);
		Factory.SetupCreate(_command, RefreshToken);
		SessionTokenGenerator.SetupGenerate(_command, RefreshToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserInvalidDetailsAndNameIsInvalid()
	{
		// Arrange
		Repository.RemoveGetByNameAsync(_command, _include, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserInvalidDetailsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserInvalidDetailsAndPasswordIsInvalid()
	{
		// Arrange
		PasswordHasher.SetupIsMismatch(_command, User);

		// Assert
		await _service.ShouldThrowUserInvalidDetailsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserNameEmailNotConfirmedException_WhenUserNameEmailNotConfirmed()
	{
		// Arrange
		var unconfirmedUser = UserBuilder.WithUnconfirmedEmail().Build();
		Repository.SetupGetByNameAsync(_command, _include, unconfirmedUser, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.IssueAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, RefreshToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallTheRepositoryGetByNameAsync_WhenCommandIsValid()
	{
		// Act
		await _service.IssueAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByNameAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallThePasswordHasherIsMismatch_WhenCommandIsValid()
	{
		// Act
		await _service.IssueAsync(_command, CancellationToken);

		// Assert
		PasswordHasher.ShouldHaveReceivedOneIsMismatch(_command, User);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.IssueAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command, RefreshToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallTheRefreshTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.IssueAsync(_command, CancellationToken);

		// Assert
		await RefreshTokenRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldCallTheSessionTokenGeneratorGenerate_WhenCommandIsValid()
	{
		// Act
		await _service.IssueAsync(_command, CancellationToken);

		// Assert
		SessionTokenGenerator.ShouldHaveReceivedOneGenerate(_command, RefreshToken);
	}
}
