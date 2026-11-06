using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatPresentationCommandUnitTest : BaseChatsCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseChatPresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
	}
}
