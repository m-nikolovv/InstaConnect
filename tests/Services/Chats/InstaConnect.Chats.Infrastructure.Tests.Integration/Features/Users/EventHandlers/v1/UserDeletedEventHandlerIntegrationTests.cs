using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Builders;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.EventHandlers.v1;

public class UserDeletedEventHandlerIntegrationTests : BaseUserInfrastructureEventHandlerIntegrationTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	private readonly UserDeletedEventHandler _handler;

	public UserDeletedEventHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = ServiceScope.GetUserDeletedEventHandler();
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
	public async Task Consume_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await _handler.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserChats_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserChats_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userChats = await ServiceScope.GetByIdRangeAsync(UserChatIds, CancellationToken);

		// Assert
		userChats.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserChatsChatMessages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserChatsChatMessages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userChatsChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessageIds, CancellationToken);

		// Assert
		userChatsChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserChatsChatMessagesChatMessageImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userChatsChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatsChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatsChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserChatMessages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserChatMessages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userChatMessages = await ServiceScope.GetByIdRangeAsync(UserChatMessageIds, CancellationToken);

		// Assert
		userChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserChatMessagesChatMessageImages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserChatMessagesChatMessageImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(UserChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		userChatMessagesChatMessageImages.ShouldBeEmpty();
	}

}
