using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Services;

public class DeleteChatMessageCommandServiceIntegrationTests : BaseChatMessageDomainCommandIntegrationTest
{
	private readonly DeleteChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteChatMessageCommandBuilder _commandBuilder;
	private readonly DeleteChatMessageCommand _command;

	private readonly DeleteChatMessageCommandBuilder _invertedCommandBuilder;
	private readonly DeleteChatMessageCommand _invertedCommand;

	public DeleteChatMessageCommandServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ChatMessage);
		_command = _commandBuilder.Build();

		_invertedCommandBuilder = _commandBuilderFactory.Create(ChatMessage).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedCommand = _invertedCommandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Service.ShouldThrowChatMessageNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatMessageForbiddenException_WhenChatMessageForbidden()
	{
		// Arrange

		// Assert
		await Service.ShouldThrowChatMessageForbiddenExceptionAsync(_invertedCommand, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithMessageId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_command, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishChatMessageDeletedNotification_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithMessageId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, ChatMessage);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenCommandIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await Service.DeleteAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Service.DeleteAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Service.DeleteAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteInvertedChatMessage_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithMessageId(transformer).Build();

		// Act
		await Service.DeleteAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenCommandIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		await Service.DeleteAsync(_invertedCommand, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedCommand, InvertedChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		await Service.DeleteAsync(invertedCommand, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, InvertedChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		await Service.DeleteAsync(invertedCommand, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, InvertedChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishInvertedChatMessageDeletedNotification_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithMessageId(transformer).Build();

		// Act
		await Service.DeleteAsync(invertedCommand, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, InvertedChatMessage);
	}
}
