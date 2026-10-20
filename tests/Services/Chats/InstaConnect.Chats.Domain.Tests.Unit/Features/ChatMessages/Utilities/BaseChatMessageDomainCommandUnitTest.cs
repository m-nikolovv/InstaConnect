using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainCommandUnitTest : BaseChatMessageTest
{
	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IImageHandler ImageHandler { get; }

	protected IChatMessageFactory Factory { get; }

	protected IChatCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IChatMessageSummarizer MessageSummarizer { get; }

	protected IChatMessageImageFactory MessageImageFactory { get; }

	protected IChatMessageCommandRepository MessageRepository { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IChatMessageNotificationService NotificationService { get; }

	protected IChatMessageImageCommandRepository MessageImageRepository { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		ImageHandler = MockFactory.CreateImageHandler();
		Factory = ChatMessageDomainMockFactory.CreateFactory();
		Repository = ChatDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		MessageSummarizer = ChatMessageMockFactory.CreateSummarizer();
		MessageImageFactory = ChatMessageImageDomainMockFactory.CreateFactory();
		MessageRepository = ChatMessageDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = ChatMockFactory.CreateIncludeBuilderFactory();
		NotificationService = ChatMessageDomainMockFactory.CreateNotificationService();
		MessageImageRepository = ChatMessageImageDomainMockFactory.CreateCommandRepository();
		MessageIncludeBuilderFactory = ChatMessageMockFactory.CreateIncludeBuilderFactory();
	}
}
