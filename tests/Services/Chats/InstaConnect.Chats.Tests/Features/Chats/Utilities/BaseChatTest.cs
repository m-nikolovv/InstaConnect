using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatTest : BaseTest
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

	protected BaseChatTest()
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
	}
}
