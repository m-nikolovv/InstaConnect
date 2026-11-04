using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class IndexKeysExtensions
{
	extension<TEntity>(IndexKeysDefinitionBuilder<TEntity> builder)
	{
		public IndexKeysDefinition<TEntity> AscendingDateTime(Expression<Func<TEntity, DateTimeOffset>> field)
		{
			return new DateTimeOffsetIndexKeysDefinition<TEntity>(1, field);
		}
	}
}
