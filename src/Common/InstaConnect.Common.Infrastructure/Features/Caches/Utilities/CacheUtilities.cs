namespace InstaConnect.Common.Infrastructure.Features.Caches.Utilities;

public static class CacheUtilities
{
	public static string GetDependencyKey(string tag)
	{
		const string Format = "cache:dependencies:{0}";

		return Format.FormatCurrentCulture(tag);
	}
}
