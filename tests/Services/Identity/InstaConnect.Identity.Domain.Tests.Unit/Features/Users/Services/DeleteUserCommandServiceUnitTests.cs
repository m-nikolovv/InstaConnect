namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

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

		_service = new(
			Factory,
			Mapper,
			ImageHandler,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			EmailConfirmationTokenFactory,
			EmailConfirmationTokenEmailSender,
			EmailConfirmationTokenRepository);

		Repository.SetupGetByIdAsync(_command, User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsyncForUserDeleted_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, User, CancellationToken);
	}
}
