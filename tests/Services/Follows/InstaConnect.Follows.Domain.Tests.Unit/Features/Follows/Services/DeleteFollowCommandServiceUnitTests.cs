namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class DeleteFollowCommandServiceUnitTests : BaseFollowDomainCommandUnitTest
{
	private readonly DeleteFollowCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteFollowCommandBuilder _commandBuilder;
	private readonly DeleteFollowCommand _command;

	private readonly FollowInclude _include;

	private readonly FollowCommandService _service;

	public DeleteFollowCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Follow);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, UserRepository, NotificationService, IncludeBuilderFactory);

		Repository.SetupGetByIdAsync(_command, _include, Follow, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowFollowNotFoundException_WhenFollowNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, Follow, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
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
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, Follow, CancellationToken);
	}
}
