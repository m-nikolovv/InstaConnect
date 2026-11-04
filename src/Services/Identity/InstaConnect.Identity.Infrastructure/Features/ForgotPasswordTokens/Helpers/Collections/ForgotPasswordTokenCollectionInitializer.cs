namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenCollectionInitializer : MongoDbCollectionInitializer<ForgotPasswordToken>
{
	public ForgotPasswordTokenCollectionInitializer(IMongoCollection<ForgotPasswordToken> collection)
		: base(
			collection,
			[
				new(Builders<ForgotPasswordToken>.IndexKeys.Ascending(c => c.Id.Id.Id)),
				new(Builders<ForgotPasswordToken>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
