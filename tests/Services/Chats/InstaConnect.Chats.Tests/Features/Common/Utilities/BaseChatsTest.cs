using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Tests.Features.Users.Builders;

namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public abstract class BaseChatsTest : BaseTest
{
	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }

	protected UserIdBuilderFactory UserIdBuilderFactory { get; }
	protected UserIdBuilder UserIdBuilder { get; }
	protected UserId UserId { get; }

	protected UserIdRangeBuilderFactory UserIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder UserIdRangeBuilder { get; }
	protected ICollection<UserId> UserIds { get; }

	protected UserBuilderFactory ParticipantOneBuilderFactory { get; }
	protected UserBuilder ParticipantOneBuilder { get; }
	protected User ParticipantOne { get; }
	protected ICollection<User> ParticipantOnes { get; }

	protected UserIdBuilderFactory ParticipantOneIdBuilderFactory { get; }
	protected UserIdBuilder ParticipantOneIdBuilder { get; }
	protected UserId ParticipantOneId { get; }

	protected UserIdRangeBuilderFactory ParticipantOneIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder ParticipantOneIdRangeBuilder { get; }
	protected ICollection<UserId> ParticipantOneIds { get; }

	protected UserBuilderFactory ParticipantTwoBuilderFactory { get; }
	protected UserBuilder ParticipantTwoBuilder { get; }
	protected User ParticipantTwo { get; }
	protected ICollection<User> ParticipantTwos { get; }

	protected UserIdBuilderFactory ParticipantTwoIdBuilderFactory { get; }
	protected UserIdBuilder ParticipantTwoIdBuilder { get; }
	protected UserId ParticipantTwoId { get; }

	protected UserIdRangeBuilderFactory ParticipantTwoIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder ParticipantTwoIdRangeBuilder { get; }
	protected ICollection<UserId> ParticipantTwoIds { get; }

	protected ChatBuilderFactory ChatBuilderFactory { get; }
	protected ChatBuilder ChatBuilder { get; }
	protected Chat Chat { get; }
	protected ICollection<Chat> Chats { get; }
	protected Chat InvertedChat { get; }
	protected ICollection<Chat> InvertedChats { get; }

	protected ChatIdBuilderFactory ChatIdBuilderFactory { get; }
	protected ChatIdBuilder ChatIdBuilder { get; }
	protected ChatId ChatId { get; }
	protected ChatIdBuilder InvertedChatIdBuilder { get; }
	protected ChatId InvertedChatId { get; }

	protected ChatIdRangeBuilderFactory ChatIdRangeBuilderFactory { get; }
	protected ChatIdRangeBuilder ChatIdRangeBuilder { get; }
	protected ICollection<ChatId> ChatIds { get; }
	protected ChatIdRangeBuilder InvertedChatIdRangeBuilder { get; }
	protected ICollection<ChatId> InvertedChatIds { get; }

	protected ChatMessageBuilderFactory ChatMessageBuilderFactory { get; }
	protected ChatMessageBuilder ChatMessageBuilder { get; }
	protected ChatMessage ChatMessage { get; }
	protected ICollection<ChatMessage> ChatMessages { get; }
	protected ChatMessage InvertedChatMessage { get; }

	protected ChatMessageIdBuilderFactory ChatMessageIdBuilderFactory { get; }
	protected ChatMessageIdBuilder ChatMessageIdBuilder { get; }
	protected ChatMessageId ChatMessageId { get; }
	protected ChatMessageIdBuilder InvertedChatMessageIdBuilder { get; }
	protected ChatMessageId InvertedChatMessageId { get; }

	protected ChatMessageIdRangeBuilderFactory ChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder ChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> ChatMessageIds { get; }
	protected ChatMessageIdRangeBuilder InvertedChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> InvertedChatMessageIds { get; }

	protected ChatMessageImageBuilderFactory ChatMessageImageBuilderFactory { get; }
	protected ChatMessageImageBuilder ChatMessageImageBuilder { get; }
	protected ChatMessageImage ChatMessageImage { get; }
	protected ICollection<ChatMessageImage> ChatMessageImages { get; }

	protected ChatMessageImageIdBuilderFactory ChatMessageImageIdBuilderFactory { get; }
	protected ChatMessageImageIdBuilder ChatMessageImageIdBuilder { get; }
	protected ChatMessageImageId ChatMessageImageId { get; }

	protected ChatMessageImageIdRangeBuilderFactory ChatMessageImageIdRangeBuilderFactory { get; }
	protected ChatMessageImageIdRangeBuilder ChatMessageImageIdRangeBuilder { get; }
	protected ICollection<ChatMessageImageId> ChatMessageImageIds { get; }

	protected BaseChatsTest()
	{
		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create();
		User = UserBuilder.Build();
		Users = User.Generate();

		UserIdBuilderFactory = new();
		UserIdBuilder = UserIdBuilderFactory.Create(User.Id);
		UserId = UserIdBuilder.Build();

		UserIdRangeBuilderFactory = new();
		UserIdRangeBuilder = UserIdRangeBuilderFactory.Create([.. Users.Select(p => p.Id)]);
		UserIds = UserIdRangeBuilder.Build();

		ParticipantOneBuilderFactory = UserBuilderFactory;
		ParticipantOneBuilder = UserBuilder;
		ParticipantOne = User;
		ParticipantOnes = Users;

		ParticipantOneIdBuilderFactory = UserIdBuilderFactory;
		ParticipantOneIdBuilder = UserIdBuilder;
		ParticipantOneId = UserId;

		ParticipantOneIdRangeBuilderFactory = UserIdRangeBuilderFactory;
		ParticipantOneIdRangeBuilder = UserIdRangeBuilder;
		ParticipantOneIds = UserIds;

		ParticipantTwoBuilderFactory = new();
		ParticipantTwoBuilder = ParticipantTwoBuilderFactory.Create();
		ParticipantTwo = ParticipantTwoBuilder.Build();
		ParticipantTwos = ParticipantTwo.Generate();

		ParticipantTwoIdBuilderFactory = new();
		ParticipantTwoIdBuilder = ParticipantTwoIdBuilderFactory.Create(ParticipantTwo.Id);
		ParticipantTwoId = ParticipantTwoIdBuilder.Build();

		ParticipantTwoIdRangeBuilderFactory = new();
		ParticipantTwoIdRangeBuilder = ParticipantTwoIdRangeBuilderFactory.Create([.. ParticipantTwos.Select(p => p.Id)]);
		ParticipantTwoIds = ParticipantTwoIdRangeBuilder.Build();

		ChatBuilderFactory = new();
		ChatBuilder = ChatBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		Chat = ChatBuilder.BuildAttached();
		Chats = Chat.GenerateAttached(ParticipantOnes, ParticipantTwos);
		InvertedChat = ChatBuilder.WithParticipantOne(ParticipantTwo).WithParticipantTwo(ParticipantOne).BuildAttached();
		InvertedChats = InvertedChat.GenerateAttached(ParticipantTwos, ParticipantOnes);

		ChatIdBuilderFactory = new();
		ChatIdBuilder = ChatIdBuilderFactory.Create(Chat.Id);
		ChatId = ChatIdBuilder.Build();
		InvertedChatIdBuilder = ChatIdBuilderFactory.Create(InvertedChat.Id);
		InvertedChatId = InvertedChatIdBuilder.Build();

		ChatIdRangeBuilderFactory = new();
		ChatIdRangeBuilder = ChatIdRangeBuilderFactory.Create([.. Chats.Select(c => c.Id)]);
		ChatIds = ChatIdRangeBuilder.Build();
		InvertedChatIdRangeBuilder = ChatIdRangeBuilderFactory.Create([.. InvertedChats.Select(c => c.Id)]);
		InvertedChatIds = InvertedChatIdRangeBuilder.Build();

		ChatMessageBuilderFactory = new();
		ChatMessageBuilder = ChatMessageBuilderFactory.Create(Chat);
		ChatMessage = ChatMessageBuilder.BuildAttached();
		ChatMessages = ChatMessage.GenerateAttached(Chats);

		ChatMessageIdBuilderFactory = new();
		ChatMessageIdBuilder = ChatMessageIdBuilderFactory.Create(ChatMessage.Id);
		ChatMessageId = ChatMessageIdBuilder.Build();
		InvertedChatMessageIdBuilder = ChatMessageIdBuilderFactory.Create(ChatMessage.Id).WithParticipantOneId(ParticipantTwoId).WithParticipantTwoId(ParticipantOneId);
		InvertedChatMessageId = InvertedChatMessageIdBuilder.Build();

		ChatMessageIdRangeBuilderFactory = new();
		ChatMessageIdRangeBuilder = ChatMessageIdRangeBuilderFactory.Create([.. ChatMessages.Select(c => c.Id)]);
		ChatMessageIds = ChatMessageIdRangeBuilder.Build();
		InvertedChatMessageIdRangeBuilder = ChatMessageIdRangeBuilderFactory.Create([.. ChatMessageIds.Select(id => ChatMessageIdBuilderFactory.Create(id).WithParticipantOneId(id.Id.ParticipantTwoId).WithParticipantTwoId(id.Id.ParticipantOneId).Build())]);
		InvertedChatMessageIds = InvertedChatMessageIdRangeBuilder.Build();

		ChatMessageImageBuilderFactory = new();
		ChatMessageImageBuilder = ChatMessageImageBuilderFactory.Create(ChatMessage);
		ChatMessageImage = ChatMessageImageBuilder.BuildAttached();
		ChatMessageImages = ChatMessageImage.GenerateAttached(ChatMessages);
		InvertedChatMessage = ChatMessageBuilderFactory.Create(ChatMessage).WithSender(ParticipantTwo).Build();

		ChatMessageImageIdBuilderFactory = new();
		ChatMessageImageIdBuilder = ChatMessageImageIdBuilderFactory.Create(ChatMessageImage.Id);
		ChatMessageImageId = ChatMessageImageIdBuilder.Build();

		ChatMessageImageIdRangeBuilderFactory = new();
		ChatMessageImageIdRangeBuilder = ChatMessageImageIdRangeBuilderFactory.Create([.. ChatMessageImages.Select(c => c.Id)]);
		ChatMessageImageIds = ChatMessageImageIdRangeBuilder.Build();
	}
}
