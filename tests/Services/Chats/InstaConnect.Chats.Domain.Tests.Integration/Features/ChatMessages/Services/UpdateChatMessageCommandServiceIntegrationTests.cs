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

public class UpdateChatMessageCommandServiceIntegrationTests : BaseChatMessageDomainCommandIntegrationTest
{
	private readonly UpdateChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateChatMessageCommandBuilder _commandBuilder;
	private readonly UpdateChatMessageCommand _command;

	public UpdateChatMessageCommandServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ChatMessage);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatMessageNotFoundException_WhenMessageIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Service.ShouldThrowChatMessageNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatMessageForbiddenException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).Build();

		// Assert
		await Service.ShouldThrowChatMessageForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishChatMessageUpdatedNotification_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, chatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId, transformer).WithParticipantTwoId(ParticipantOneId).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId, transformer).WithParticipantTwoId(ParticipantOneId).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId, transformer).WithParticipantTwoId(ParticipantOneId).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(command, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilder.WithSenderId(ParticipantTwoId).Build();
		await ServiceScope.UpdateAsync(updatedChatMessage, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId).WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(command, chatMessage);
	}
}
