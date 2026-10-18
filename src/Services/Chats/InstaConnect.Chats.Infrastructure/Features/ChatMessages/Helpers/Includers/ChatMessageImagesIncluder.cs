using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatMessageImagesIncluder : IChatMessageIncluder
{
	private readonly IMongoCollection<ChatMessageImage> _collection;

	public ChatMessageImagesIncluder(IMongoCollection<ChatMessageImage> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.ChatMessage;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ChatMessageImage;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				i => i.Id.Id,
				p => p.ChatMessageImages
			);
	}
}
