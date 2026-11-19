namespace InstaConnect.Common.Infrastructure.Features.Databases.Utilities;

public static class MongoDbCollations
{
	private const string Locale = "en";

	public static Collation IgnoreCase => new(Locale, strength: CollationStrength.Primary);
}
