using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Services;

public class DeleteUserClaimCommandServiceUnitTests : BaseUserClaimDomainCommandUnitTest
{
	private readonly DeleteUserClaimCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserClaimCommandBuilder _commandBuilder;
	private readonly DeleteUserClaimCommand _command;

	private readonly UserClaimInclude _include;

	private readonly UserClaimCommandService _service;

	public DeleteUserClaimCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(UserClaim);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_service = new(Mapper, EventPublisher, Factory, Repository, ClaimRepository, IncludeBuilderFactory);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		ClaimRepository.SetupGetByIdAsync(_command, _include, UserClaim, CancellationToken);
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
	public async Task DeleteAsync_ShouldThrowUserClaimNotFoundException_WhenUserClaimNotFound()
	{
		// Arrange
		ClaimRepository.RemoveGetByIdAsync(_command, _include, UserClaim, CancellationToken);

		// Assert
		await _service.ShouldThrowUserClaimNotFoundExceptionAsync(_command, CancellationToken);
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
	public async Task DeleteAsync_ShouldCallTheClaimRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await ClaimRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheClaimRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await ClaimRepository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, UserClaim, CancellationToken);
	}
}
