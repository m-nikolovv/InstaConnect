using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollection : MongoDbCollection<Chat>, IChatCollection
{
	private readonly IChatFluentFactory _fluentFactory;

	public ChatCollection(
		ISessionHandler sessionHandler,
		IChatFluentFactory fluentFactory,
		IMongoCollection<Chat> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IChatFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
