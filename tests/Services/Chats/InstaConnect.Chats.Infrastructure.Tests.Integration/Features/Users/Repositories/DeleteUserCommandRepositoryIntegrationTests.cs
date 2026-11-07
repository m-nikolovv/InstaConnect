namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
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
		var deletedUser = UserBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedUser, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChats_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
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
		var deletedUser = UserBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedUser, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatsChatMessages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
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
		var deletedUser = UserBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedUser, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
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
		var deletedUser = UserBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedUser, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatMessages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
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
		var deletedUser = UserBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedUser, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserChatMessagesChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
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
		var deletedUser = UserBuilder.WithId(transformer).Build();

		// Act
		await Repository.DeleteAsync(deletedUser, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

}
