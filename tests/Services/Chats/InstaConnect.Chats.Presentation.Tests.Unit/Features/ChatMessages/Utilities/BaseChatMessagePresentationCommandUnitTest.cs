using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandUnitTest : BaseChatMessageTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseChatMessagePresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
	}
}
