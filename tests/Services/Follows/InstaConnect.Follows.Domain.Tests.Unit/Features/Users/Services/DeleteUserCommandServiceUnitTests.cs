using InstaConnect.Follows.Domain.Features.Users.Helpers;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Builders;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Services;

public class DeleteUserCommandServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly DeleteUserCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserCommandBuilder _commandBuilder;
	private readonly DeleteUserCommand _command;

	private readonly UserCommandService _service;

	public DeleteUserCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(UserFactory, UserRepository);

		UserRepository.SetupGetByIdAsync(_command, User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheUserRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}
}
