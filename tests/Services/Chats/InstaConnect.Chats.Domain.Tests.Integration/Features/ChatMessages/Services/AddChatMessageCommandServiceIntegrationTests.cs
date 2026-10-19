using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Services;

public class AddChatMessageCommandServiceIntegrationTests : BaseChatMessageDomainCommandIntegrationTest
{
	private readonly AddChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatMessageCommandBuilder _commandBuilder;
	private readonly AddChatMessageCommand _command;

	private readonly AddChatMessageCommandBuilder _invertedCommandBuilder;
	private readonly AddChatMessageCommand _invertedCommand;

	public AddChatMessageCommandServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Chat, ChatMessage.ChatMessageImages.Count);
		_command = _commandBuilder.Build();

		_invertedCommandBuilder = _commandBuilderFactory.Create(Chat, ChatMessage.ChatMessageImages.Count).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedCommand = _invertedCommandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(_command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfy(command, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedCommand, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(invertedCommand, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(_invertedCommand);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedCommand);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedCommand);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(invertedCommand);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(_invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, chatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notificationRequest = await MessageNotificationClient.PublishedAddedAsync(CancellationToken);

		// Assert
		notificationRequest.ShouldSatisfyInverted(invertedCommand, chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfy(command);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddChatMessageImages_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(_invertedCommand);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedCommand);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldSatisfyInverted(invertedCommand);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldAddInvertedChatMessageImages_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var invertedCommand = _invertedCommandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(invertedCommand, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ChatMessageImages.ShouldBeEmpty();
	}
}
