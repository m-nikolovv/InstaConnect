using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Services;

public class UpdateChatMessageCommandServiceIntegrationTests : BaseChatMessageDomainCommandIntegrationTest
{
	private readonly UpdateChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateChatMessageCommandBuilder _commandBuilder;
	private readonly UpdateChatMessageCommand _command;

	private readonly UpdateChatMessageCommandBuilder _invertedCommandBuilder;
	private readonly UpdateChatMessageCommand _invertedCommand;

	public UpdateChatMessageCommandServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	public async Task UpdateAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Assert
		await Service.ShouldThrowChatMessageNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowChatMessageForbiddenException_WhenChatMessageForbidden()
	{
		// Arrange

		// Assert
		await Service.ShouldThrowChatMessageForbiddenExceptionAsync(_invertedCommand, CancellationToken);
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
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await Service.UpdateAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedCommand, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnInvertedResponse_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedCommand, chatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await Service.UpdateAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(_invertedCommand);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedCommand);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedCommand);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateInvertedChatMessage_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedCommand);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandIsValid()
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);

		// Act
		var response = await Service.UpdateAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishInvertedChatMessageUpdatedNotification_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.UpdateAsync(InvertedChatMessage, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, chatMessage);
	}
}
