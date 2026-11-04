namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollectionInitializer : MongoDbCollectionInitializer<User>
{
	public UserCollectionInitializer(IMongoCollection<User> collection)
		: base(
			collection,
			[
				new(Builders<User>.IndexKeys.Ascending(c => c.Id.Id)),
				new(Builders<User>.IndexKeys.Ascending(c => c.Name.Value)),
				new(Builders<User>.IndexKeys.Ascending(c => c.Email.Value))
			])
	{
	}
}
