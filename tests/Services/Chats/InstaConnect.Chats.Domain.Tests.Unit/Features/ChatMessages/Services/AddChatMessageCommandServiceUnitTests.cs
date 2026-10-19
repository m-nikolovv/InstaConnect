using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class AddChatMessageCommandServiceUnitTests : BaseChatMessageDomainCommandUnitTest
{
	private readonly AddChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatMessageCommandBuilder _commandBuilder;
	private readonly AddChatMessageCommand _command;

	private readonly ChatInclude _include;

	private readonly ChatMessageCommandService _service;

	public AddChatMessageCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Chat, ChatMessage.ChatMessageImages.Count);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		_service = new(Mapper, ImageHandler, Repository, DateTimeProvider, Factory, MessageSummarizer, MessageImageFactory, MessageRepository, IncludeBuilderFactory, MessageImageRepository, NotificationService, MessageIncludeBuilderFactory);

		Repository.SetupGetByIdAsync(_command, _include, Chat, CancellationToken);
		Factory.SetupCreate(_command, ChatMessage);
		MessageImageFactory.SetupCreateRange(_command, ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatNotFoundException_WhenChatNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, ChatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await _service.AddAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheMessageRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldCallTheMessageRepositoryAddAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await MessageRepository.ShouldHaveReceivedOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheMessageSummarizerSummarizeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await MessageSummarizer.ShouldHaveReceivedOneSummarizeAsync(_command, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldCallTheMessageSummarizerSummarizeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await MessageSummarizer.ShouldHaveReceivedOneSummarizeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheNotificationServiceAddedAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await NotificationService.ShouldHaveReceivedOneAddedAsync(_command, ChatMessage, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldCallTheNotificationServiceAddedAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await NotificationService.ShouldHaveReceivedOneAddedAsync(command, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheImageHandlerUploadRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadRangeAsync(_command, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheImageHandlerUploadRangeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedZeroUploadRangeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheMessageImageFactoryCreateRange_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		MessageImageFactory.ShouldHaveReceivedOneCreateRange(_command, ChatMessage);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheMessageImageFactoryCreateRange_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		MessageImageFactory.ShouldHaveReceivedZeroCreateRange(command, ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheMessageImageRepositoryAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await MessageImageRepository.ShouldHaveReceivedOneAddRangeAsync(_command, CancellationToken);
	}

	[Theory]
	[ChatMessageImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheMessageImageRepositoryAddRangeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await MessageImageRepository.ShouldHaveReceivedZeroAddRangeAsync(command, CancellationToken);
	}
}
