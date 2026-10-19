using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Services;

public class AddChatCommandServiceIntegrationTests : BaseChatDomainCommandIntegrationTest
{
	private readonly AddChatCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatCommandBuilder _commandBuilder;
	private readonly AddChatCommand _command;

	private readonly AddChatCommandBuilder _invertedCommandBuilder;
	private readonly AddChatCommand _invertedCommand;

	public AddChatCommandServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_command = _commandBuilder.Build();

		_invertedCommandBuilder = _commandBuilderFactory.Create(ParticipantOne, ParticipantTwo).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		_invertedCommand = _invertedCommandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFoundAndParticipantOneIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantOne, CancellationToken);

		// Assert
		await Service.ShouldThrowParticipantOneNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFoundAndParticipantTwoIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ParticipantTwo, CancellationToken);

		// Assert
		await Service.ShouldThrowParticipantTwoNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(_invertedCommand, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(invertedCommand, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Chat, CancellationToken);
		var invertedCommand = _invertedCommandBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(invertedCommand, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, chat);
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
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chat);
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
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, chat);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChat_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChat_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChat_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, chat);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, chat);
	}
}
