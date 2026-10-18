using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageDomainCommandUnitTest : BaseChatMessageImageTest
{
	protected IGuidProvider GuidProvider { get; }

	protected IChatMessageImageFactory Factory { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IChatMessageImageCommandRepository Repository { get; }

	protected BaseChatMessageImageDomainCommandUnitTest()
	{
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		Factory = ChatMessageImageDomainMockFactory.CreateFactory();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Repository = ChatMessageImageDomainMockFactory.CreateCommandRepository();
	}
}
