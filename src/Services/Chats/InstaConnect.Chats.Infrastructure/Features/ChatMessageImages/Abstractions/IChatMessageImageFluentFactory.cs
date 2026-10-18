using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageFluentFactory
{
	public IChatMessageImageFluent Create(IAggregateFluent<ChatMessageImage> fluent);
}
