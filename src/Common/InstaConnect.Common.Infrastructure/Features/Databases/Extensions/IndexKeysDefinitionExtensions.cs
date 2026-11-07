namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class IndexKeysDefinitionExtensions
{
	extension<T>(IndexKeysDefinition<T> keys)
	{
		public CreateIndexModel<T> ToIndex()
		{
			return new(keys, new());
		}

		public CreateIndexModel<T> Unique()
		{
			return keys.ToIndex().Unique();
		}

		public CreateIndexModel<T> ExpireAfter(TimeSpan expireAfter)
		{
			return keys.ToIndex().ExpireAfter(expireAfter);
		}
	}
}
