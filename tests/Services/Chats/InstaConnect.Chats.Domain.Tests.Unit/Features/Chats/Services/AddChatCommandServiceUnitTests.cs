using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Services;

public class AddChatCommandServiceUnitTests : BaseChatDomainCommandUnitTest
{
	private readonly AddChatCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatCommandBuilder _commandBuilder;
	private readonly AddChatCommand _command;

	private readonly ChatCommandService _service;

	public AddChatCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_command = _commandBuilder.Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, UserRepository);

		UserRepository.SetupGetParticipantOneByIdAsync(_command, ParticipantOne, CancellationToken);
		UserRepository.SetupGetParticipantTwoByIdAsync(_command, ParticipantTwo, CancellationToken);
		Factory.SetupCreate(_command, Chat);
		Repository.RemoveGetByIdAsync(_command, Chat, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowParticipantOneNotFoundException_WhenParticipantOneNotFound()
	{
		// Arrange
		UserRepository.RemoveGetParticipantOneByIdAsync(_command, ParticipantOne, CancellationToken);

		// Assert
		await _service.ShouldThrowParticipantOneNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowParticipantTwoNotFoundException_WhenParticipantTwoNotFound()
	{
		// Arrange
		UserRepository.RemoveGetParticipantTwoByIdAsync(_command, ParticipantTwo, CancellationToken);

		// Assert
		await _service.ShouldThrowParticipantTwoNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		Repository.SetupGetByIdAsync(_command, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, Chat);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByParticipantOneIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByParticipantOneIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByParticipantTwoIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByParticipantTwoIdAsync(_command, CancellationToken);
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
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, Chat, CancellationToken);
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
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, Chat, CancellationToken);
	}
}
