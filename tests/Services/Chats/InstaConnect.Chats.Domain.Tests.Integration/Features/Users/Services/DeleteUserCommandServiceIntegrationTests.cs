using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Users.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Users.Services;

public class DeleteUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly DeleteUserCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserCommandBuilder _commandBuilder;
	private readonly DeleteUserCommand _command;

	public DeleteUserCommandServiceIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await UserService.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChats_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserChats_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatsChatMessages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserChatsChatMessages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatMessages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserChatMessages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatMessagesChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserChatMessagesChatMessageImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

}
