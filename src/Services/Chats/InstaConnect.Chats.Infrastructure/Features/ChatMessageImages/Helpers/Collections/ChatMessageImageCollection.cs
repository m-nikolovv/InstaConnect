using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageCollection : MongoDbCollection<ChatMessageImage>, IChatMessageImageCollection
{
	private readonly IChatMessageImageFluentFactory _fluentFactory;

	public ChatMessageImageCollection(
		ISessionHandler sessionHandler,
		IChatMessageImageFluentFactory fluentFactory,
		IMongoCollection<ChatMessageImage> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IChatMessageImageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken)
	{
		await DeleteRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
