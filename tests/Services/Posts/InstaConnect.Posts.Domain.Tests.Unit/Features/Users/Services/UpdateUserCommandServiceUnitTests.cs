using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Users.Helpers;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Builders;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Users.Services;

public class UpdateUserCommandServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	private readonly UserCommandService _service;

	public UpdateUserCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(UserFactory, UserRepository);

		UserRepository.SetupGetByIdAsync(_command, User, CancellationToken);
		UserRepository.SetupIsNameUniqueAsync(_command, User, CancellationToken);
		UserRepository.SetupIsEmailUniqueAsync(_command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithEmail(user.Email).Build();
		UserRepository.RemoveIsEmailUniqueAsync(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExists()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithName(user.Name).Build();
		UserRepository.RemoveIsNameUniqueAsync(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsNameUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsNameUniqueAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsNameUniqueAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsNameUniqueAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsNameUniqueAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsEmailUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsEmailUniqueAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsEmailUniqueAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsEmailUniqueAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsEmailUniqueAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryIsEmailUniqueAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}
}
