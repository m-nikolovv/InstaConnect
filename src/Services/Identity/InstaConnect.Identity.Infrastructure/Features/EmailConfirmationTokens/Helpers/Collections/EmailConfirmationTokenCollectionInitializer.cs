namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenCollectionInitializer : MongoDbCollectionInitializer<EmailConfirmationToken>
{
	public EmailConfirmationTokenCollectionInitializer(IMongoCollection<EmailConfirmationToken> collection)
		: base(
			collection,
			[
				new(Builders<EmailConfirmationToken>.IndexKeys.Ascending(c => c.Id.Id.Id)),
				new(Builders<EmailConfirmationToken>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
