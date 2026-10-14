using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageTest : BaseTest
{
	protected UserBuilderFactory ParticipantOneBuilderFactory { get; }
	protected UserBuilder ParticipantOneBuilder { get; }
	protected User ParticipantOne { get; }
	protected ICollection<User> ParticipantOnes { get; }

	protected UserBuilderFactory ParticipantTwoBuilderFactory { get; }
	protected UserBuilder ParticipantTwoBuilder { get; }
	protected User ParticipantTwo { get; }
	protected ICollection<User> ParticipantTwos { get; }

	protected ChatBuilderFactory ChatBuilderFactory { get; }
	protected ChatBuilder ChatBuilder { get; }
	protected Chat Chat { get; }
	protected ICollection<Chat> Chats { get; }

	protected ChatMessageBuilderFactory ChatMessageBuilderFactory { get; }
	protected ChatMessageBuilder ChatMessageBuilder { get; }
	protected ChatMessage ChatMessage { get; }
	protected ICollection<ChatMessage> ChatMessages { get; }

	protected BaseChatMessageTest()
	{
		ParticipantOneBuilderFactory = new();
		ParticipantOneBuilder = ParticipantOneBuilderFactory.Create();
		ParticipantOne = ParticipantOneBuilder.Build();
		ParticipantOnes = ParticipantOne.Generate();

		ParticipantTwoBuilderFactory = new();
		ParticipantTwoBuilder = ParticipantTwoBuilderFactory.Create();
		ParticipantTwo = ParticipantTwoBuilder.Build();
		ParticipantTwos = ParticipantTwo.Generate();

		ChatBuilderFactory = new();
		ChatBuilder = ChatBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		Chat = ChatBuilder.Build();
		Chats = Chat.Generate(ParticipantOnes, ParticipantTwos);

		ChatMessageBuilderFactory = new();
		ChatMessageBuilder = ChatMessageBuilderFactory.Create(Chat);
		ChatMessage = ChatMessageBuilder.Build();
		ChatMessages = ChatMessage.Generate(Chats);
	}
}
