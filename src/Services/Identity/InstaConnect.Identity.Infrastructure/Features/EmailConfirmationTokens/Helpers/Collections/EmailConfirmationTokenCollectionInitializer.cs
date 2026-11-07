namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenCollectionInitializer : MongoDbCollectionInitializer<EmailConfirmationToken>
{
	public EmailConfirmationTokenCollectionInitializer(IMongoCollection<EmailConfirmationToken> collection)
		: base(
			collection,
			[
				Builders<EmailConfirmationToken>.IndexKeys.Ascending(c => c.Id.Id.Id).ToIndex(),
				Builders<EmailConfirmationToken>.IndexKeys.Ascending(c => c.Id.Id).ToIndex(),
				Builders<EmailConfirmationToken>.IndexKeys.Ascending(c => c.ExpiresAtUtc).ExpireAt()
			])
	{
	}
}
