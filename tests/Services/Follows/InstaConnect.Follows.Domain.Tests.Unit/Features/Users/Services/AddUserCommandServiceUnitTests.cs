using InstaConnect.Follows.Domain.Features.Users.Helpers;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Builders;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Services;

public class AddUserCommandServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	private readonly UserCommandService _service;

	public AddUserCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();

		_service = new(UserFactory, UserRepository);

		UserFactory.SetupCreate(_command, User);
		UserRepository.SetupIsNameUniqueAsync(_command, User, CancellationToken);
		UserRepository.SetupIsEmailUniqueAsync(_command, User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenUserAlreadyExists()
	{
		// Arrange
		var command = _commandBuilder.WithId(UserId).Build();
		UserRepository.SetupExistsByIdAsync(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();
		UserRepository.RemoveIsEmailUniqueAsync(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExists()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();
		UserRepository.RemoveIsNameUniqueAsync(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, User);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		UserFactory.ShouldHaveReceivedOneCreate(_command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryIsNameUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryIsEmailUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneIsEmailUniqueAsync(_command, CancellationToken);
	}
}
