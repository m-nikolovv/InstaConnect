using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class UpdateChatMessageCommandServiceUnitTests : BaseChatMessageDomainCommandUnitTest
{
	private readonly UpdateChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateChatMessageCommandBuilder _commandBuilder;
	private readonly UpdateChatMessageCommand _command;

	private readonly UpdateChatMessageCommandBuilder _invertedCommandBuilder;
	private readonly UpdateChatMessageCommand _invertedCommand;

	private readonly ChatInclude _include;
	private readonly ChatMessageInclude _messageInclude;

	private readonly ChatMessageCommandService _service;

	public UpdateChatMessageCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ChatMessage);
		_command = _commandBuilder.Build();

		_invertedCommandBuilder = _commandBuilderFactory.Create(ChatMessage).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedCommand = _invertedCommandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		_messageInclude = MessageIncludeBuilderFactory.Create().WithSender().WithChat(_include).WithChatMessageImages().Build();

		_service = new(Mapper, ImageHandler, Repository, DateTimeProvider, Factory, MessageSummarizer, MessageImageFactory, MessageRepository, IncludeBuilderFactory, MessageImageRepository, NotificationService, MessageIncludeBuilderFactory);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		MessageRepository.SetupGetByIdAsync(_command, _messageInclude, ChatMessage, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, ChatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		MessageRepository.RemoveGetByIdAsync(_command, _messageInclude, ChatMessage, CancellationToken);

		// Assert
		await _service.ShouldThrowChatMessageNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatMessageForbiddenException_WhenChatMessageForbidden()
	{
		// Arrange
		Repository.SetupExistsByIdAsync(_invertedCommand, CancellationToken);
		MessageRepository.SetupGetByIdAsync(_invertedCommand, _messageInclude, ChatMessage, CancellationToken);

		// Assert
		await _service.ShouldThrowChatMessageForbiddenExceptionAsync(_invertedCommand, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, ChatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheMessageRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _messageInclude, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(_command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheMessageRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneUpdateAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheMessageSummarizerSummarizeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await MessageSummarizer.ShouldHaveReceivedOneSummarizeAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheNotificationServiceUpdatedAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await NotificationService.ShouldHaveReceivedOneUpdatedAsync(_command, ChatMessage, CancellationToken);
	}
}
