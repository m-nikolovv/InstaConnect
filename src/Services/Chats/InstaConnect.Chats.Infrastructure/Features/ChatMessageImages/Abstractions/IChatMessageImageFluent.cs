using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageFluent : IMongoDbFluent<ChatMessageImage>
{
	public IChatMessageImageFluent Match(ChatMessageImageId filter);

	public IChatMessageImageFluent Match(IEnumerable<ChatMessageImageId> filter);
}
