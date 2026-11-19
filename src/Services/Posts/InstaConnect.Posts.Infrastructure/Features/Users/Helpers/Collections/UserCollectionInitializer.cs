namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollectionInitializer : MongoDbCollectionInitializer<User>
{
	public UserCollectionInitializer(IMongoCollection<User> collection)
		: base(
			collection,
			[
				Builders<User>.IndexKeys.Ascending(c => c.Id.Id).ToIndex(),
				Builders<User>.IndexKeys.Ascending(c => c.Name.Value).ToIndex(),
				Builders<User>.IndexKeys.Ascending(c => c.Email.Value).ToIndex()
			])
	{
	}
}
