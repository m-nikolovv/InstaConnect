using InstaConnect.Chats.Application.Features.Users.Commands.Delete;
using InstaConnect.Chats.Application.Tests.Features.Users.Builders;
using InstaConnect.Chats.Application.Tests.Integration.Features.Users.Utilities;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Users.Handlers;

public class DeleteUserCommandHandlerIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
	private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserCommandRequestBuilder _requestBuilder;
	private readonly DeleteUserCommandRequest _request;

	public DeleteUserCommandHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserChats_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserChats_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserChatsChatMessages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserChatsChatMessages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserChatMessages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserChatMessages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserChatMessagesChatMessageImages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserChatMessagesChatMessageImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

}
