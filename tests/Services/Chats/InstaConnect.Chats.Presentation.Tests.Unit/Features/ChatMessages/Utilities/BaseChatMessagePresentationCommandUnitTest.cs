using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandUnitTest : BaseChatsCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseChatMessagePresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
	}
}
