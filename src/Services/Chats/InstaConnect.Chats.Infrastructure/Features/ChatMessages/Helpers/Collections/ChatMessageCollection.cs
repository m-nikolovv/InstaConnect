namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageCollection : MongoDbCollection<ChatMessage>, IChatMessageCollection
{
	private readonly IChatMessageFluentFactory _fluentFactory;

	public ChatMessageCollection(
		ISessionHandler sessionHandler,
		IChatMessageFluentFactory fluentFactory,
		IMongoCollection<ChatMessage> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IChatMessageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
