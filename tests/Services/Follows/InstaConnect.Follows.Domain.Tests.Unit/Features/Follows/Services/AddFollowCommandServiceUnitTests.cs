using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class AddFollowCommandServiceUnitTests : BaseFollowDomainCommandUnitTest
{
	private readonly AddFollowCommandBuilderFactory _commandBuilderFactory;
	private readonly AddFollowCommandBuilder _commandBuilder;
	private readonly AddFollowCommand _command;

	private readonly FollowCommandService _service;

	public AddFollowCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Follower, Following);
		_command = _commandBuilder.Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, UserRepository, NotificationService, IncludeBuilderFactory);

		UserRepository.SetupGetFollowerByIdAsync(_command, Follower, CancellationToken);
		UserRepository.SetupGetFollowingByIdAsync(_command, Following, CancellationToken);
		Factory.SetupCreate(_command, Follow);
		Repository.RemoveExistsByIdAsync(_command, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFoundAndFollowerIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetFollowerByIdAsync(_command, Follower, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowerNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFoundAndFollowingIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetFollowingByIdAsync(_command, Following, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowingNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
	{
		// Arrange
		Repository.SetupExistsByIdAsync(_command, Follow, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, Follow);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByFollowerIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByFollowerIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByFollowingIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByFollowingIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_command, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheNotificationServiceAddedAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await NotificationService.ShouldHaveReceivedOneAddedAsync(_command, Follow, CancellationToken);
	}
}
