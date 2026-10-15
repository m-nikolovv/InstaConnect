using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public abstract class BaseChatTest : BaseTest
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

	protected BaseChatTest()
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
	}
}
