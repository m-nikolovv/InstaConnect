using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageTest : BaseTest
{
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

	protected ChatIdBuilderFactory ChatIdBuilderFactory { get; }
	protected ChatIdBuilder ChatIdBuilder { get; }
	protected ChatId ChatId { get; }

	protected ChatIdRangeBuilderFactory ChatIdRangeBuilderFactory { get; }
	protected ChatIdRangeBuilder ChatIdRangeBuilder { get; }
	protected ICollection<ChatId> ChatIds { get; }

	protected ChatMessageBuilderFactory ChatMessageBuilderFactory { get; }
	protected ChatMessageBuilder ChatMessageBuilder { get; }
	protected ChatMessage ChatMessage { get; }
	protected ICollection<ChatMessage> ChatMessages { get; }

	protected ChatMessageIdBuilderFactory ChatMessageIdBuilderFactory { get; }
	protected ChatMessageIdBuilder ChatMessageIdBuilder { get; }
	protected ChatMessageId ChatMessageId { get; }

	protected ChatMessageIdRangeBuilderFactory ChatMessageIdRangeBuilderFactory { get; }
	protected ChatMessageIdRangeBuilder ChatMessageIdRangeBuilder { get; }
	protected ICollection<ChatMessageId> ChatMessageIds { get; }

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

	protected BaseChatMessageTest()
	{
		ParticipantOneBuilderFactory = new();
		ParticipantOneBuilder = ParticipantOneBuilderFactory.Create();
		ParticipantOne = ParticipantOneBuilder.Build();
		ParticipantOnes = ParticipantOne.Generate();

		ParticipantOneIdBuilderFactory = new();
		ParticipantOneIdBuilder = ParticipantOneIdBuilderFactory.Create(ParticipantOne.Id);
		ParticipantOneId = ParticipantOneIdBuilder.Build();

		ParticipantOneIdRangeBuilderFactory = new();
		ParticipantOneIdRangeBuilder = ParticipantOneIdRangeBuilderFactory.Create([.. ParticipantOnes.Select(p => p.Id)]);
		ParticipantOneIds = ParticipantOneIdRangeBuilder.Build();

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
		Chat = ChatBuilder.Build();
		Chats = Chat.Generate(ParticipantOnes, ParticipantTwos);

		ChatIdBuilderFactory = new();
		ChatIdBuilder = ChatIdBuilderFactory.Create(Chat.Id);
		ChatId = ChatIdBuilder.Build();

		ChatIdRangeBuilderFactory = new();
		ChatIdRangeBuilder = ChatIdRangeBuilderFactory.Create([.. Chats.Select(c => c.Id)]);
		ChatIds = ChatIdRangeBuilder.Build();

		ChatMessageBuilderFactory = new();
		ChatMessageBuilder = ChatMessageBuilderFactory.Create(Chat);
		ChatMessage = ChatMessageBuilder.Build();
		ChatMessages = ChatMessage.Generate(Chats);

		ChatMessageIdBuilderFactory = new();
		ChatMessageIdBuilder = ChatMessageIdBuilderFactory.Create(ChatMessage.Id);
		ChatMessageId = ChatMessageIdBuilder.Build();

		ChatMessageIdRangeBuilderFactory = new();
		ChatMessageIdRangeBuilder = ChatMessageIdRangeBuilderFactory.Create([.. ChatMessages.Select(c => c.Id)]);
		ChatMessageIds = ChatMessageIdRangeBuilder.Build();

		ChatMessageImageBuilderFactory = new();
		ChatMessageImageBuilder = ChatMessageImageBuilderFactory.Create(ChatMessage);
		ChatMessageImage = ChatMessageImageBuilder.Build();
		ChatMessageImages = ChatMessageImage.Generate(ChatMessages);

		ChatMessageImageIdBuilderFactory = new();
		ChatMessageImageIdBuilder = ChatMessageImageIdBuilderFactory.Create(ChatMessageImage.Id);
		ChatMessageImageId = ChatMessageImageIdBuilder.Build();

		ChatMessageImageIdRangeBuilderFactory = new();
		ChatMessageImageIdRangeBuilder = ChatMessageImageIdRangeBuilderFactory.Create([.. ChatMessageImages.Select(c => c.Id)]);
		ChatMessageImageIds = ChatMessageImageIdRangeBuilder.Build();
	}
}
